using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class Categoria
    {
        [Required(ErrorMessage = "El nombre de la categoría es requerido")]
        public string Nombre { get; set; }
    }

    public class CategoriaResponse : Categoria
    {
        public Guid IdCategoria { get; set; }
    }
}
