using Autofac;
using ChessWithTDD;

namespace ChessGameController
{
    /// <summary>
    /// Container used to map abstract dependencies to their implementations.
    /// The design should be such that we only need to call Resolve once in the application,
    /// and the chain of dependencies should be resolved recursively.
    /// </summary>
    public class ContainerConfiguration
    {
        public static IContainer Container;

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            //board itself
            builder.RegisterType<Board>().As<IBoard>();

            //service locator
            builder.RegisterType<StrictServiceLocator>().As<IStrictServiceLocator>();

            //the services themselves. They should have one instance per board, which is the context of 
            //the lifetime scope 
            builder.RegisterType<BoardCache>().As<IBoardCache>().InstancePerLifetimeScope();
            builder.RegisterType<BoardInitialiser>().As<IBoardInitialiser>().InstancePerLifetimeScope();

            builder.RegisterType<CheckManager>().As<ICheckManager>().InstancePerLifetimeScope();
            builder.RegisterType<CheckMateManager>().As<ICheckMateManager>().InstancePerLifetimeScope();
            builder.RegisterType<CheckMateEscapeManager>().As<ICheckMateEscapeManager>().InstancePerLifetimeScope();

            builder.RegisterType<MoveValidator>().As<IMoveValidator>().InstancePerLifetimeScope();
            builder.RegisterType<GenericMoveValidator>().As<IGenericMoveValidator>().InstancePerLifetimeScope();
            builder.RegisterType<MultiSquareMoveValidator>().As<IMultiSquareMoveValidator>().InstancePerLifetimeScope();
            builder.RegisterType<MoveIntoCheckValidator>().As<IMoveIntoCheckValidator>().InstancePerLifetimeScope();

            builder.RegisterType<PawnManager>().As<IPawnManager>().InstancePerLifetimeScope();
            builder.RegisterType<EnPassantManager>().As<IEnPassantManager>().InstancePerLifetimeScope();

            builder.RegisterType<MoveExecutor>().As<IMoveExecutor>().InstancePerLifetimeScope();

            Container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
