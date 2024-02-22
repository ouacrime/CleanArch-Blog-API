using AutoMapper;
using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom<>);
           
            var mappingMethodName = nameof(IMapFrom<object>.Mapping);
            
            bool HasInterface(Type t) =>
                t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;
           
            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList(); 

            var argumentTypes = new Type[] {typeof(Profile)};

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodeInfo = type.GetMethod(mappingMethodName);

                if (methodeInfo != null)
                {
                    methodeInfo.Invoke(instance, new object[] {this});
                }
                else
                {
                    var Interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                    if(Interfaces.Count > 0)
                    {
                        foreach (var @interface in Interfaces)
                        {
                            var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

                            interfaceMethodInfo?.Invoke(instance,new object[] {this});

                        }

                    }
                }



            }



        }

            

    }
}
