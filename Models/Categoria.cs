using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace  EF_NET.Models;
public class Categoria
{
    //[Key]
    public Guid CategoriaId { get; set; }

    // [Required]
    // [MaxLength (150)]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string peso { get; set; }

    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas { get; set; }
}
