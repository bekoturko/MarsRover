using System;

namespace HBCaseStudy.Business.Abstract.Services
{
    /// <summary>
    /// Loglama sistemine erişim sağlar.
    /// </summary>
    public interface ILoggingService
    {
        /// <summary>
        /// Hata mesajını ve oluşan hata nesnesinide loglamak için kullanılır.
        /// </summary>
        /// <param name="methodName">Hata durumunun bulunduğu metot ismi</param>
        /// <param name="message">Log mesajı</param>
        /// <param name="ex">Exception tipinde oluşan hata</param>
        void LogError(string methodName, string message, Exception ex);

        /// <summary>
        /// Hata mesajını loglamak için kullanılır.
        /// </summary>
        /// <param name="methodName">Hata durumunun bulunduğu metot ismi</param>
        /// <param name="message">Log mesajı</param>
        void LogError(string methodName, string message);

        /// <summary>
        /// Uyarı mesajını loglamak için kullanılır.
        /// </summary>
        /// <param name="methodName">Uyarı durumunun bulunduğu metot ismi</param>
        /// <param name="message">Log mesajı</param>
        void LogWarning(string methodName, string message);

        /// <summary>
        /// Bilgi mesajını loglamak için kullanılır.
        /// </summary>
        /// <param name="methodName">Bilgi durumunun bulunduğu metot ismi</param>
        /// <param name="message">Log mesajı</param>
        void LogInformation(string methodName, string message);

        /// <summary>
        /// Ayırt edici bilgi mesajını loglamak için kullanılır.
        /// </summary>
        /// <param name="methodName">Bilgi durumunun bulunduğu metot ismi</param>
        /// <param name="message">Log mesajı</param>
        void LogDebug(string methodName, string message);
    }
}