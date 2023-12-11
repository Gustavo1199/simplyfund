using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Email.NotificationsModel
{
    public class Notification : EntityBase
    {
        public string? Name { get; set; }
        public string? NotificationSubject { get; set; }
        public int NotificationExecutionTypeId { get; set; }
        public int Delay { get; set; }
        public int NotificationModuleId { get; set; }
        public bool IsEnabled { get; set; }
        public int NotificationActionId { get; set; }
        public int NotificationTargetId { get; set; }
        public string? Body { get; set; }

        public virtual NotificationAction? NotificationAction { get; set; }
        public virtual NotificationModule? NotificationModule { get; set; }
        public virtual NotificationTarget? NotificationTarget { get; set; }
        public virtual NotificationExecutionType? NotificationExecutionType { get; set; }
    }
}
