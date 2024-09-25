using TextFormatControllers;
using TextFormatControllers.TextFormatters;
using UserInterface;
using Zenject;

namespace Infrastructure
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAppEngine();
            BindUserInterface();
        }

        private void BindAppEngine()
        {
            Container.Bind<HalfWordPainter>().AsSingle();
            Container.Bind<TextFormatHandler>().FromComponentInHierarchy().AsSingle();
        }

        private void BindUserInterface()
        {
            Container.Bind<AppMessage>().FromComponentInHierarchy().AsSingle();
            Container.Bind<TextReceivingButton>().FromComponentInHierarchy().AsSingle();
        }
    }
}