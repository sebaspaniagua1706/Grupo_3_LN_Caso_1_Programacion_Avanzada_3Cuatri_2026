using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public abstract class GeneratorBase<T> : IGenerator
        where T : class
    {
        protected readonly IRepositoryBase<T> Repository;

        protected GeneratorBase(IRepositoryBase<T> repository)
        {
            Repository = repository;
        }

        public abstract string EntityName { get; }

        protected abstract IEnumerable<T> CreateData();

        public int Count()
        {
            return Repository.Count();
        }

        public GeneratorResult Generate()
        {
            try
            {
                if (Repository.Any())
                {
                    return new GeneratorResult
                    {
                        Success = false,
                        GeneratedRecords = 0,
                        Message = "La tabla " + EntityName +
                                  " ya contiene registros."
                    };
                }

                var data = CreateData().ToList();

                if (!data.Any())
                {
                    return new GeneratorResult
                    {
                        Success = false,
                        GeneratedRecords = 0,
                        Message = "No se generaron datos para " + EntityName + "."
                    };
                }

                Repository.AddRange(data);

                return new GeneratorResult
                {
                    Success = true,
                    GeneratedRecords = data.Count,
                    Message = "Se generaron " + data.Count +
                              " registros en " + EntityName + "."
                };
            }
            catch (Exception ex)
            {
                return new GeneratorResult
                {
                    Success = false,
                    GeneratedRecords = 0,
                    Message = "Error generando " + EntityName +
                              ": " + ex.Message
                };
            }
        }
    }
}