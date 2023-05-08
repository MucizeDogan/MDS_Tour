using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApiForSql.DAL;
using SignalRApiForSql.Hubs;

namespace SignalRApiForSql.Models
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        // burada metotlarımızı çağıracağız..

        // Bu metotumuzda verileri listeleyeceğiz
        public IQueryable<  /*Burada bir çıkış parametresi istiyor bizden bu da bizim üzerinde çalıştığımız entitymiz yani Visitor*/   Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }

        //Bu metotumuzda verilerimizi kaydedeceğiz(Visitors)
        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor); //visitor parametresinden gelen değerleri ekle
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallVisitorList", "aaa"); //SignalR da çağırılacak olan metotlar SendAsync metodu ile çağırılıyor.
            // CallVisitorList i çağırdığımda sen bana GetVisitorChartList i getir dedik yukarıda
        }

        //Bu metot chartıma verileri yansıtacak olan metodumuz
        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())    //Burada bir tane sorgu komutu  oluşturacağız.--->command
            {
                command.CommandText = "query";    //Command isimli değişkenimden gelen kısma bir CommandText ataması yap yani komut değeri ata  ="sorgu gelecek"
                command.CommandType = System.Data.CommandType.Text; // Göndermiş olduğum Command in CommandType ı text 
                _context.Database.OpenConnection(); //Bağlantıyı aç sorgu döndüreceğiz.
                using (var reader = command.ExecuteReader())    // Bir tane okuyucu oluştur(reader) command den gelen değeri oku(executeReader) 
                {
                    while (reader.Read())    //reader komutu okuma işlemi yaptığı sürece
                    {
                        VisitorChart visitorChart = new VisitorChart(); //VisitorChart sınıfından bir visitorchart nesnesi örnekledik.
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString(); //visitorChartın visitorDate ine  okunan değer içerisinde tarih değerini al 
                        Enumerable.Range(1, 5).ToList().ForEach(x =>//bir Enumarable oluşturacağız ve buna Range ile aralık vereceğiz bu aralığıda oluşrduğumuz Ecity deki şehir sayısına göre vereceğiz
                        // Her biri için şunu yap(ForEach(x=>) 
                        {
                            visitorChart.Counts.Add(reader.GetInt32(x));   // Türetmiş olduğum visitorChart ın Counts un içerisine ekle okumuş olduğum sayısal değeri ilgili chartımızın içerisine
                        });

                        visitorCharts.Add(visitorChart); //visitorCharts ın içerisine ekle visitorChart ı 
                    }
                }
                _context.Database.CloseConnection();
                return visitorCharts;
            }
        }
    }
}
