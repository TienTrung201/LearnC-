public class HinhChuNhat
{

    public int ChieuDai { get; set; }
    public int ChieuRong { get; set; }

    public HinhChuNhat(int _ChieuDai, int _ChieuRong){
        ChieuDai=_ChieuDai;
        ChieuRong=_ChieuRong;
    }
    public int Dientich=>ChieuDai*ChieuRong;

}