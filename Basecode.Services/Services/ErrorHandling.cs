using Basecode.Data.ViewModels;
using System;

namespace Basecode.Services.Services
{
    public class ErrorHandling
    {
        public class LogContent
        {
            public string ErrorCode { get; set; } = string.Empty;
            public DateTime Time { get; set; }
            public string Message { get; set; } = string.Empty;
            public bool Result { get; set; } = false;

            public LogContent CheckJobOpening(JobOpeningViewModel jobOpening)
            {
                if (string.IsNullOrEmpty(jobOpening.Title) || jobOpening.Title.Length > 50)
                {
                    SetError("400", "Title length is 0 or more than 50 characters.");
                    return this;
                }

                if (string.IsNullOrEmpty(jobOpening.EmploymentType))
                {
                    SetError("400", "The Employment Type is required but has no value.");
                    return this;
                }

                if (string.IsNullOrEmpty(jobOpening.Location))
                {
                    SetError("400", "The Location is required but has no value.");
                    return this;
                }

                if (string.IsNullOrEmpty(jobOpening.WorkSetup))
                {
                    SetError("400", "The Work Setup is required but has no value.");
                    return this;
                }

                if (jobOpening.Qualifications == null || jobOpening.Qualifications.Count == 0)
                {
                    SetError("400", "The Qualifications list is empty.");
                    return this;
                }
                else
                {
                    foreach (var qualification in jobOpening.Qualifications)
                    {
                        if (string.IsNullOrEmpty(qualification.Description))
                        {
                            SetError("400", "Qualification details are empty.");
                            return this;
                        }
                    }
                }

                if (jobOpening.Responsibilities == null || jobOpening.Responsibilities.Count == 0)
                {
                    SetError("400", "The Responsibilities list is empty.");
                    return this;
                }
                else
                {
                    foreach (var responsibility in jobOpening.Responsibilities)
                    {
                        if (string.IsNullOrEmpty(responsibility.Description))
                        {
                            SetError("400", "Responsibility details are empty.");
                            return this;
                        }
                    }
                }

                return this;
            }

            private void SetError(string errorCode, string errorMessage)
            {
                Result = true;
                ErrorCode = errorCode;
                Message = errorMessage;
            }
        }

        public static string SetLog(LogContent logContent)
        {
            return $"ErrorCode: {logContent.ErrorCode}. Message: \"{logContent.Message}\"";
        }

        public static string DefaultException(string message)
        {
            return $"ErrorCode: 500. Message: \"{message}\"";
        }
    }
}
