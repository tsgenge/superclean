using SuperClean.Application.Exceptions;
using SuperClean.Application.Shared.Interfaces;
using System.Reflection;

namespace SuperClean.Application.Aggregates
{
    public abstract class AggregateBase
    {
        private MethodInfo[] _applyMethods = new MethodInfo[] { };
        protected void Apply(IEvent @event)
        {
            var applyMethod = GetApplyMethod(@event.GetType());
            applyMethod.Invoke(this, new object[] { @event });
        }

        private MethodInfo GetApplyMethod(Type eventType)
        {
            if (_applyMethods.Length == 0)
                _applyMethods = this.GetType().GetMethods().Where(s => s.Name == nameof(Apply)).ToArray();

            return _applyMethods!.SingleOrDefault(m => m.GetParameters()[0].ParameterType == eventType)
                ?? throw new EventNotSupportedException();
        }
    }
}
