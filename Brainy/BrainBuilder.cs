using Brainy.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brainy
{
    public class BrainBuilder : IBrainBuilder
    {
        public static IBrainBuilder CreateBrain()
        {
            return new BrainBuilder();
        }

        public static IBrainBuilder CreateBrain<TBrain>() where TBrain : IBrain, new()
        {
            return new BrainBuilder(new TBrain());
        }
        private IBrain brain;

        private BrainBuilder()
        {
            brain = new Brain();
        }

        private BrainBuilder(IBrain brain)
        {
            this.brain = brain;
        }

        public IBrainBuilder AddPresenter<TPresenter>() where TPresenter : IBrainPresenter, new()
        {
            brain.Presenters.Add(new TPresenter());
            return this;
        }

        public IBrainBuilder AddSensor<TSensor>() where TSensor : IBrainSensor, new()
        {
            brain.Sensors.Add(new TSensor());
            return this;
        }

        public IBrainBuilder AddSkill<TSkill>() where TSkill : IBrainSkill, new()
        {
            var skill = new TSkill();
            brain.Skills.Add(skill);
            skill.AssignOrders(order =>
            {
                brain.SkillSelector.AssignSkill(order, skill);
                ((Brain)brain).AddSkillsHelp(order, skill);
            });
            return this;
        }

        public IBrain Build()
        {
            return brain;
        }
    }
}
