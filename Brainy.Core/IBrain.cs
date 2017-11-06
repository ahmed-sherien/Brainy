using System;
using System.Collections.Generic;

namespace Brainy.Core
{
    public interface IBrain
    {
        List<IBrainSkill> Skills { get; }
        List<IBrainSensor> Sensors { get; }
        List<IBrainPresenter> Presenters { get; }
        ISkillSelector SkillSelector { get; }
        void Run();
        void Stop();

        event EventHandler Stopped;
    }
}
