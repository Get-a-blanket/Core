using System.ComponentModel.DataAnnotations;

namespace GaB_Core.UnprotectedDbConnector.Models
{
    /// <summary>
    /// Описание вендингового аппарата
    /// </summary>
    public class VendingMachine
    {
        /// <summary>
        /// GUID аппарата
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        
        /// <summary>
        /// Количество пледов готовых к выдаче
        /// </summary>
        public int NumberOfCellsWBlankets { get; set; }

        /// <summary>
        /// Количество ячеек для возврата
        /// </summary>
        public int NumberOfEmptyCells { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Широта
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Полное описание местоположения автомата
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Краткое описание местоположения
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Код автомата
        /// </summary>
        [Required]
        public int Code { get; set; }
    }
}
