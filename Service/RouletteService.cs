using Microsoft.Extensions.Configuration;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Service
{
    public class RouletteService : IRouletteService
    {

        private readonly IRedisRepository _redisRepository;
        private readonly string _rouletteKey;
        private readonly string _rouletteBetKey;
        public RouletteService(IRedisRepository redisRepository, IConfiguration config)
        {
            _redisRepository = redisRepository;
            _rouletteKey = config["RedisKeys:Roulettes"];
            _rouletteBetKey = config["RedisKeys:RouletteBets"];
        }
        public int CreateRoulette(RouletteCreatePayload payload)
        {
            var roulettes = GetRoulettes();
            var roulette = new Roulette
            {
                Id = payload.Id,
                Status = false,
                OpenDate = DateTime.MinValue,
                CloseDate = DateTime.MinValue
            };
            roulettes.Add(roulette);
            var roulettesJson = JsonSerializer.Serialize(roulettes);
            var result = _redisRepository.Set(_rouletteKey, roulettesJson);
            return (result) ? payload.Id : 0;

        }
        public List<Roulette> GetRoulettes()
        {

            var result = _redisRepository.Get(_rouletteKey);
            if (string.IsNullOrWhiteSpace(result))
            {
                return new List<Roulette>();
            }
            var roulettes = JsonSerializer.Deserialize<List<Roulette>>(result);
            return roulettes;

        }

        public Roulette GetRouletteById(int id)
        {

            var roulettes = GetRoulettes();
            return roulettes.Where(r => r.Id == id).FirstOrDefault();

        }

        public bool OpenRoulette(RouletteOpenPayload payload)
        {
            var roulette = GetRouletteById(payload.Id);

            if (roulette != null)
            {
                roulette.Status = true;
                roulette.OpenDate = DateTime.UtcNow;
                var roulettes = GetRoulettes();
                var indexOf = roulettes.IndexOf(roulettes.Find(p => p.Id == payload.Id));
                roulettes[indexOf] = roulette;
                var roulettesJson = JsonSerializer.Serialize(roulettes);
                var result = _redisRepository.Set(_rouletteKey, roulettesJson);

                return result;
            }

            return false;

        }


        public bool CreateRouletteBet(RouletteBetPayload payload)
        {
            var roulette = GetRouletteById(payload.RouletteId);
            if (roulette == null || !roulette.Status)
            {
                return false;
            }

            var rouletteBets = GetRouletteBets();
            var rouletteBet = new RouletteBet
            {
                RouletteId = payload.RouletteId,
                UserId = payload.UserId,
                NumberOrColorBet = payload.NumberOrColorBet,
                MoneyBet = payload.MoneyBet
            };
            rouletteBets.Add(rouletteBet);
            var rouletteBetsJson = JsonSerializer.Serialize(rouletteBets);
            var result = _redisRepository.Set(_rouletteBetKey, rouletteBetsJson);
            return result;

        }

        public List<RouletteBet> GetRouletteBets()
        {

            var result = _redisRepository.Get(_rouletteBetKey);
            if (string.IsNullOrWhiteSpace(result))
            {
                return new List<RouletteBet>();
            }
            var rouletteBets = JsonSerializer.Deserialize<List<RouletteBet>>(result);
            return rouletteBets;

        }

        public List<RouletteBet> GetRouletteBetsByRouletteId(int rouletteId)
        {
            var rouletteBets = GetRouletteBets();
            var bets = rouletteBets.Where(r => r.RouletteId == rouletteId).ToList();
            return bets;
        }


        public RouletteDto CloseRoulette(RouletteClosePayload payload)
        {
            var roulette = GetRouletteById(payload.Id);
            if (roulette == null)
            {
                return new RouletteDto();
            }
            roulette.Status = false;
            roulette.CloseDate = DateTime.UtcNow;
            var roulettes = GetRoulettes();
            var indexOf = roulettes.IndexOf(roulettes.Find(p => p.Id == payload.Id));
            roulettes[indexOf] = roulette;
            var roulettesJson = JsonSerializer.Serialize(roulettes);
            var result = _redisRepository.Set(_rouletteKey, roulettesJson);
            var rouletteData = new RouletteDto
            {
                Id = roulette.Id,
                Status = roulette.Status,
                OpenDate = roulette.OpenDate,
                CloseDate = roulette.CloseDate,
                RouletteBets = GetRouletteBetsByRouletteId(roulette.Id)
            };

            return rouletteData;

        }


    }
}
