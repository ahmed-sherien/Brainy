using System;
using System.Collections.Generic;
using System.Text;

namespace Brainy.Core
{
    public interface IBrainBuilder
    {
        IBrainBuilder AddSkill<TSkill>() where TSkill : IBrainSkill, new();
        IBrainBuilder AddSensor<TSensor>() where TSensor : IBrainSensor, new();
        IBrainBuilder AddPresenter<TPresenter>() where TPresenter : IBrainPresenter, new();
        IBrain Build();
    }
}
