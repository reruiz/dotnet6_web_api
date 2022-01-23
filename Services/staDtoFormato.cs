namespace dotnet6_web_api.Services
{
    /// <summary>
    ///Clase para unir nombre e id en las Clases DTO, con
    ///el fín de facilitar la lectura de las claves foraneas
    ///Se utiliza en algunos casos especiales.
    /// </summary>
    public static class DtoFormato
    {
        public static string EntidadId { get; set; }
        public static string EntidadNombre { get; set; }

        public static string NombreId()
        {
            return EntidadId.ToString() + " | " + EntidadNombre;
        }
    }
}