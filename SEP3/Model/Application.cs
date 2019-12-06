using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SEP3.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApplicationAnswer
    {
        APPROVED,
        DECLINED,
        NOT_ANSWERED
    }


    public class Application
    {
        public string ProjectId { get; set; }
        public ITProvider Provider { get; set; }
        public string ApplicationText { get; set; }
        public DateTime Date { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ApplicationAnswer Answer { get; set; }

        public Application() { }

        public Application(string projectId, ITProvider provider, string applicationText, DateTime date)
        {
            this.ProjectId = projectId;
            this.Provider = provider;
            this.ApplicationText = applicationText;
            this.Date = date;
            this.Answer = ApplicationAnswer.NOT_ANSWERED;
        }

        public Application(string projectId, ITProvider provider, string applicationText, DateTime date, ApplicationAnswer answer)
        {
            this.ProjectId = projectId;
            this.Provider = provider;
            this.ApplicationText = applicationText;
            this.Date = date;
            this.Answer = answer;
        }
    }
}
