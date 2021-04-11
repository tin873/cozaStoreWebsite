using System.ComponentModel;

namespace cozaStore.Models
{
    public enum Status
    {
        [Description("Chờ xác nhận")]
        waitForConfirm,

        [Description("Đang giao")]
        shipping,

        [Description("Đã giao")]
        delivered,

        [Description("Đã hủy")]
        cancelled,
    }

}
