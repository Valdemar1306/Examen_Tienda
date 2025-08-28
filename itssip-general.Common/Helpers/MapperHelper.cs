using System.Reflection;
using System.Reflection.Emit;

namespace itssip_general.Common.Helpers
{
    /// <summary>
    /// Clase que realiza el mapeo de las entidades.
    /// </summary>
    public sealed class MapperHelper : ObjectCopyBase
    {
        /// <summary>
        /// Instancia única de la clase.
        /// </summary>
        private static MapperHelper instance;

        /// <summary>
        /// Instancia especificada a nulo.
        /// </summary>
        public static MapperHelper Instance => instance ??= new MapperHelper();

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        private MapperHelper()
        {
        }
        

        /// <summary>
        /// Diccionario que define las keys de los objetos a mapear.
        /// </summary>
        private readonly Dictionary<string, DynamicMethod> _del = new();

        /// <summary>
        /// Inicializa los objetos a mapear.
        /// </summary>
        /// <param name="source">Tipo del objeto origen.</param>
        /// <param name="target">Tipo del objeto destino.</param>
        public override void MapTypes(Type source, Type target)
        {
            var key = this.GetMapKey(source, target);
            if (this._del.ContainsKey(key))
            {
                return;
            }

            // var args = new[] { source, target };
            // var mod = typeof(Program).Module;

            var dm = new DynamicMethod(key, null, new[] { source, target }, typeof(MapperHelper).Module);
            var il = dm.GetILGenerator();
            // var maps = this.GetMatchingProperties(source, target);

            foreach (var map in this.GetMatchingProperties(source, target))
            {
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_0);
                il.EmitCall(OpCodes.Callvirt, map.SourceProperty.GetGetMethod(), null);
                il.EmitCall(OpCodes.Callvirt, map.TargetProperty.GetSetMethod(), null);
            }
            il.Emit(OpCodes.Ret);
            this._del.Add(key, dm);
        }

        /// <summary>
        /// Realiza el mapeo de los objetos, es decir, realiza la copia del objeto origen al objeto destino.
        /// </summary>
        /// <param name="source">Objeto origen desl que se copiara.</param>
        /// <param name="target">Objeto destino al que se le copiara el origen.</param>
        public override void Copy(object source, object target)
        {
            //var sourceType = source.GetType();
            //var targetType = target.GetType();
            //var key = this.GetMapKey(sourceType, targetType);

            //var del = this._del[key];
            //var args = new[] { source, target };
            //del.Invoke(null, args);
            this._del[this.GetMapKey(source.GetType(), target.GetType())].Invoke(null, new[] { source, target });
        }
    }

    /// <summary>
    /// Modelo que define el mapeo de propiedades.
    /// </summary>
    public class PropertyMap
    {
        /// <summary>
        /// Propiedades del objeto origen.
        /// </summary>
        public PropertyInfo SourceProperty { get; set; }

        /// <summary>
        /// Propiedades del objeto destino.
        /// </summary>
        public PropertyInfo TargetProperty { get; set; }
    }

    /// <summary>
    /// Clase abstracta que define el comportamiento del mapeo de objetos.
    /// </summary>
    public abstract class ObjectCopyBase
    {
        /// <summary>
        /// Inicializa los objetos a mapear.
        /// </summary>
        /// <param name="source">Tipo del objeto origen.</param>
        /// <param name="target">Tipo del objeto destino.</param>
        public abstract void MapTypes(Type source, Type target);

        /// <summary>
        /// Realiza el mapeo de los objetos, es decir, realiza la copia del objeto origen al objeto destino.
        /// </summary>
        /// <param name="source">Objeto origen desl que se copiara.</param>
        /// <param name="target">Objeto destino al que se le copiara el origen.</param>
        public abstract void Copy(object source, object target);

        /// <summary>
        /// Obtiene el matching de las propiedades.
        /// </summary>
        /// <param name="source">Tipo del objeto origen.</param>
        /// <param name="target">Tipo del objeto destino.</param>
        /// <returns>Lista del mapeo de propiedades.</returns>
        protected virtual IList<PropertyMap> GetMatchingProperties(Type sourceType, Type targetType)
        {
            //var sourceProperties = sourceType.GetProperties();
            //var targetProperties = targetType.GetProperties();

            //var properties = (from s in sourceProperties from t in targetProperties
            //    where s.Name == t.Name && s.CanRead && t.CanWrite && s.PropertyType == t.PropertyType
            //    select new PropertyMap
            //    {
            //        SourceProperty = s,
            //        TargetProperty = t
            //    }).ToList();

            //return properties;

            return (from s in sourceType.GetProperties()
                    from t in targetType.GetProperties()
                    where s.Name == t.Name && s.CanRead && t.CanWrite && s.PropertyType == t.PropertyType
                    select new PropertyMap
                    {
                        SourceProperty = s,
                        TargetProperty = t
                    }).ToList();
        }

        /// <summary>
        /// Obtiene la key de los objetos a mapear.
        /// </summary>
        /// <param name="source">Tipo del objeto origen.</param>
        /// <param name="target">Tipo del objeto destino.</param>
        /// <returns>Key de los objetos a mapear.</returns>
        protected virtual string GetMapKey(Type sourceType, Type targetType)
        {
            var keyName = "Copy_";
            keyName += sourceType.FullName.Replace(".", "_").Replace("+", "_");
            keyName += "_";
            keyName += targetType.FullName.Replace(".", "_").Replace("+", "_");
            return keyName;
        }
    }
}
