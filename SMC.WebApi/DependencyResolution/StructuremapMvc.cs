using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using SMC.Infrastructure.SharedKernel.IoC;
using SMC.WebApi.DependencyResolution;
using System.Web.Mvc;
using WebActivatorEx;

[assembly: System.Web.PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace SMC.WebApi.DependencyResolution
{
    public static class StructuremapMvc
    {
        #region Public Properties

        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

        #endregion Public Properties

        #region Public Methods and Operators

        public static void End()
        {
            StructureMapDependencyScope.Dispose();
        }

        public static void Start()
        {
            var container = IoC.Initialize();
            StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }

        #endregion Public Methods and Operators
    }
}