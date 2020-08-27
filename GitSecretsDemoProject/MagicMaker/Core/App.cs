using MagicMaker.Core.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace MagicMaker.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<HomeViewModel>();
        }
    }
}
