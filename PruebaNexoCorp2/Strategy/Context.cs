using Services;

namespace PruebaNexoCorp2.Strategy
{
    public class Context
    {
        private IServicePosExpress choise;
        public void SetChoise(IServicePosExpress choise)
        {
            this.choise = choise;
        }
        
        public void ExecuteChoise()
        {
            choise.RegistrarNuevoProductoErp();
        }
    }
}