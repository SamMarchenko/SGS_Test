using System.Threading.Tasks;

namespace Logic
{
    public interface IPayLoadedState<TPayLoad> : IInitExitableState
    {
        void Enter(TPayLoad payLoad);
    }
}