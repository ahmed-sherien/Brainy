using Brainy.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brainy
{
    public class Brain : IBrain
    {
        private bool _exit = false;
        public event EventHandler Stopped;

        public List<IBrainSkill> Skills { get; private set; }
        public List<IBrainSensor> Sensors { get; private set; }
        public List<IBrainPresenter> Presenters { get; private set; }
        public ISkillSelector SkillSelector { get; private set; }
        public Brain()
        {
            Skills = new List<IBrainSkill>();
            Sensors = new List<IBrainSensor>();
            Presenters = new List<IBrainPresenter>();
            SkillSelector = new SkillSelector();
            SkillSelector.AssignSkill("stop", new StoppingSkill());
        }
        public void Run()
        {
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