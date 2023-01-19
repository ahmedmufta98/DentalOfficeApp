using AutoMapper;
using DentalOffice.Dtos;
using DentalOffice.Entities.dbContext;
using DentalOffice.Entities.dbEntities;
using DentalOffice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.Repositories.Services
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RecommendationRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<DentistDto>> GetRecommendedDentists(int dentistId)
        {
            return _mapper.Map<List<DentistDto>>(await LoadSimilar(dentistId));
        }

        private async Task<List<Dentist>> LoadSimilar(int dentistId)
        {
            Dictionary<int, List<Rating>> dentists = await LoadOtherDentists(dentistId);
            List<Rating> ratingOfCurrent = await _context.Ratings.Where(x => x.DentistId == dentistId).OrderBy(x => x.UserId).ToListAsync();

            List<Rating> ratings1 = new List<Rating>();
            List<Rating> ratings2 = new List<Rating>();
            List<Dentist> recommendedDentists = new List<Dentist>();

            foreach (var dentist in dentists)
            {
                foreach (Rating rating in ratingOfCurrent)
                {
                    if (dentist.Value.Where(w => w.UserId == rating.UserId).Count() > 0)
                    {
                        ratings1.Add(rating);
                        ratings2.Add(dentist.Value.Where(w => w.UserId == rating.UserId).First());
                    }
                }

                double similarity = GetSimilarity(ratings1, ratings2);

                if (similarity > 0.5)
                {
                    var foundedDentist = await _context.Dentists.Where(w => w.Id == dentist.Key).FirstOrDefaultAsync();

                    if (foundedDentist is not null)
                        recommendedDentists.Add(foundedDentist);
                }

                ratings1.Clear();
                ratings2.Clear();
            }
            return recommendedDentists;
        }

        private double GetSimilarity(List<Rating> ratings1, List<Rating> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
                return 0;

            double x = 0, y1 = 0, y2 = 0;

            for (int i = 0; i < ratings1.Count; i++)
            {
                x += ratings1[i].Rate * ratings2[i].Rate;
                y1 += ratings1[i].Rate * ratings1[i].Rate;
                y2 += ratings2[i].Rate * ratings2[i].Rate;
            }

            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);

            double y = y1 * y2;

            if (y == 0)
                return 0;

            return x / y;
        }

        private async Task<Dictionary<int, List<Rating>>> LoadOtherDentists(int dentistId)
        {
            Dictionary<int, List<Rating>> dentists = new Dictionary<int, List<Rating>>();

            List<Dentist> list = await _context.Dentists.Where(w => w.Id != dentistId).ToListAsync();
            List<Rating> ratings = new List<Rating>();

            foreach (var item in list)
            {
                ratings = await _context.Ratings.Where(w => w.DentistId == item.Id).OrderBy(w => w.DentistId).ToListAsync();
                if (ratings.Count > 0)
                {
                    dentists.Add(item.Id, ratings);
                }
            }

            return dentists;
        }
    }
}
