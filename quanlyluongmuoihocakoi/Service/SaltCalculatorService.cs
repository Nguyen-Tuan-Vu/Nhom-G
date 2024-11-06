public class SaltCalculatorService : ISaltCalculatorService
{
    public SaltCalculationResponse CalculateSaltAmount(SaltCalculationRequest request)
    {
        // Tính the tich ho
        double volume = request.chieudaiho * request.chieurongho * request.chieusauho * 1000;

        // Kiem tra nong do muoi phu hop
        double recommendedConcentration = request.giaidoanphattrien switch
        {
            "Cá bột" => 0.25,     
            "Cá con" => 0.2,  
            "Cá trưởng thành" => 0.1,     
            _ => 0.1            
        };

        // xác định nòng độ muối
        if (request.nongdomuoi > recommendedConcentration)
        {
            return new SaltCalculationResponse
            {
                SaltAmount = 0,
                Message = $"Nồng độ muối vượt quá giới hạn khuyến nghị cho giai đoạn {request.giaidoanphattrien}."
            };
        }

        //Tính toán lượng mưới
        double saltAmount = volume * request.nongdomuoi / 100;

        return new SaltCalculationResponse
        {
            SaltAmount = saltAmount,
            Message = $"Lượng muối cần thêm là {saltAmount} gram cho hồ có thể tích {volume} lít."
        };
    }
}
