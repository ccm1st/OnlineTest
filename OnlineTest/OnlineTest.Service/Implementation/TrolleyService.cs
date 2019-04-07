using OnlineTest.Service.Domain;
using OnlineTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Service.Implementation
{
    public class TrolleyService : ITrolleyService
    {
        private readonly ITrolleyAPI _trolleyAPI;

        public TrolleyService(ITrolleyAPI trolleyAPI)
        {
            _trolleyAPI = trolleyAPI;
        }
        public async Task<decimal> CalculateTotal(string token, Trolley trolley)
        {
            try
            {
                return await _trolleyAPI.Calculate(token, trolley);
            }catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
