using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.MapperHelpers
{
    public class AutoMapperHelper
    {
        public static List<T> MapToSameTypeList<T>(List<T> list)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<T, T>(); });
            var result = Mapper.Map <List<T>, List<T>> (list);
            return result;
        }

        public static T MapToSameType<T>(T obj)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<T, T>(); });
            var result = Mapper.Map<T, T>(obj);
            return result;
        }
    }
}
