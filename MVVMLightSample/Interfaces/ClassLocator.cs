using System;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;

namespace Interfaces
{
    public static class ClassLocator
    {
        public static ISimpleIoc Instance => SimpleIoc.Default;

        public static TClass GetInstance<TClass>() where TClass
            : class => Instance.GetInstance<TClass>();

        public static object GetInstance(Type type) => Instance.GetInstance(type);

        //Not tested
        public static bool ContainsCreated(Type type)
        {
            MethodInfo method = typeof(SimpleIoc).GetMethod("ContainsCreated");
            MethodInfo generic = method.MakeGenericMethod(type);
            var x = generic.Invoke(Instance, null);
            return (bool)x;
        }

        public static void Register<TClass>(Func<TClass> action)
            where TClass : class => Instance.Register<TClass>(action);

        //Not tested
        public static void Register(Type type, Func<object> action)
        {
            MethodInfo method = typeof(SimpleIoc).GetMethod("Register");
            MethodInfo generic = method.MakeGenericMethod(type);
            var x = generic.Invoke(Instance, new object[] { action });
        }
    }
}