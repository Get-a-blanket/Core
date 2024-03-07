namespace GaB_Core.Controllers.SystemControllerModels
{
    /// <summary>
    /// Статус системы
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Текущее время на машине
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Версия Core
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// Возможность подключения к защищенной базе данных
        /// </summary>
        public string ProtectedDBVersion { get; set; }

        /// <summary>
        /// Возможность подключения к незащищенной базе данных
        /// </summary>
        public string UnprotectedDBVersion { get; set; }

    }
}
