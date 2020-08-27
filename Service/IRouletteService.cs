using Models;
using System.Collections.Generic;

namespace Service
{
    public interface IRouletteService
    {
        public int CreateRoulette(RouletteCreatePayload payload);
        bool OpenRoulette(RouletteOpenPayload payload);
        bool CreateRouletteBet(RouletteBetPayload payload);
        RouletteDto CloseRoulette(RouletteClosePayload payload);
        List<Roulette> GetRoulettes();
        Roulette GetRouletteById(int id);

    }
}
