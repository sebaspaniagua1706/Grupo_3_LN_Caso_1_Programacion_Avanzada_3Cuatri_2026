using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAP.Generators
{
    public class GeneratorStatus
    {
        public string EntityName { get; set; }

        public int CurrentRecords { get; set; }

        public bool HasData { get; set; }

        public bool CanGenerate { get; set; }

        public string[] Dependencies { get; set; }

        public string[] MissingDependencies { get; set; }

        public string DependenciesText
        {
            get
            {
                if (Dependencies == null ||
                    Dependencies.Length == 0)
                {
                    return "Ninguna";
                }

                return string.Join(", ", Dependencies);
            }
        }

        public string StatusText
        {
            get
            {
                if (HasData)
                {
                    return "Datos generados";
                }

                if (!CanGenerate)
                {
                    return "Esperando: " +
                           string.Join(", ", MissingDependencies);
                }

                return "Disponible";
            }
        }

        public string StatusClass
        {
            get
            {
                if (HasData)
                {
                    return "badge bg-success";
                }

                if (!CanGenerate)
                {
                    return "badge bg-danger";
                }

                return "badge bg-primary";
            }
        }

        public string ButtonText
        {
            get
            {
                if (HasData)
                {
                    return "Ya contiene datos";
                }

                if (!CanGenerate)
                {
                    return "Dependencias pendientes";
                }

                return "Generar datos";
            }
        }

        public string ValidationMessage
        {
            get
            {
                if (HasData)
                {
                    return "La tabla " + EntityName +
                           " ya contiene datos.";
                }

                if (!CanGenerate)
                {
                    return "Antes de generar " + EntityName +
                           " debe generar: " +
                           string.Join(", ", MissingDependencies) +
                           ".";
                }

                return string.Empty;
            }
        }
    }
}