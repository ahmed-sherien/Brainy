using Brainy.Core;
using Brainy.Core.Help;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brainy
{
    public class Brain : IBrain
    {
        private bool _exit = false;
        private HelpMeSkill helpme;

        public event EventHandler Stopped;

        public List<IBrainSkill> Skills { get; private set; }
        public List<IBrainSensor> Sensors { get; private set; }
        public List<IBrainPresenter> Presenters { get; private set; }
        public ISkillSelector SkillSelector { get; private set; }
        public Brain()
        {
            var stopping = new StoppingSkill();
            helpme = new HelpMeSkill(this);
            Skills = new List<IBrainSkill> { stopping, helpme };
            Sensors = new List<IBrainSensor>();
            Presenters = new List<IBrainPresenter>();
            SkillSelector = new SkillSelector();
            SkillSelector.AssignSkill("stop", stopping);
            SkillSelector.AssignSkill("helpme", helpme);
            helpme.AddSkillHelp("helpme", helpme);
            helpme.AddSkillHelp("stop", stopping);
        }
        internal void AddSkillsHelp(string order, IBrainSkill skill)
        {
            helpme.AddSkillHelp(order, skill);
        }
        public void Run()
        {
            Parallel.ForEach(Presenters, presenter =>
            {
                presenter.Present(helpme.HelpMe());
            });
            while (!_exit)
            {
                try
                {
                    Parallel.ForEach(Sensors, sensor =>
                    {
                        try
                        {
                            var order = sensor.Sense();
                            var skill = SkillSelector.SelectSkill(Skills, order);
                            var result = skill.Process(order);
                            if (result is StoppingResult) this.Stop();
                            Parallel.ForEach(Presenters, presenter =>
                            {
                                presenter.Present(result);
                            });
                        }
                        catch (BrainException ex)
                        {
                            Parallel.ForEach(Presenters, presenter =>
                            {
                                presenter.Present(new ExceptionResult(ex));
                            });
                        }
                    });
                }
                catch (Exception ex)
                {
                    Parallel.ForEach(Presenters, presenter =>
                    {
                        presenter.Present(new ExceptionResult(ex));
                    });
                }
            }
        }
        public void Stop()
        {
            _exit = true;
            OnStopped(new EventArgs());
        }

        private void OnStopped(EventArgs args)
        {
            Stopped?.Invoke(this, args);
        }
    }
}