using DevExpress.CodeParser;

namespace ProjectQLKTX.Models;

public  class Chitietcongto
{
    public Guid Id { get; set; }

    public int? ChiSoDauThang { get; set; }

    public int? ChiSoCuoiThang { get; set; }

    public Guid? IdCongto { get; set; }

    public virtual Congto? IdCongToNavigation { get; set; }
}
