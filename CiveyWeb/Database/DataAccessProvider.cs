using CiveyWeb.Database.DbModels;
using System.Collections.Generic;
using System.Linq;

namespace CiveyWeb.Database
    {
    public class DataAccessProvider : IDataAccessProvider
        {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
            {
            _context = context;
            }

        public List<PollDtoModel> GetPollRecords()
            {
            return _context.poll.ToList();
            }

        public List<PollDtoModel> GetPollRecordsByPageNumberAndPageSize(int pageNumber, int pageSize)
            {

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 2 : pageSize;

            return _context.poll.OrderBy(x => x.id).Skip(pageNumber-1).Take(pageSize).ToList();
            }


        public PollDtoModel GetPollRecordById(int id)
            {
            return _context.poll.FirstOrDefault(t => t.id == id);
            }

        public void AddPollRecord(PollDtoModel poll)
            {
            _context.poll.Add(poll);
            _context.SaveChanges();
            }

        public List<AnswersDtoModel> GetAnswerRecords()
            {
            return _context.answer.ToList();
            }

        public List<AnswersDtoModel> GetAnswerRecordByPollId(long pollId)
            {
            return _context.answer.Where(t => t.poll_id == pollId).ToList();
            }

        public void AddAnswerRecord(AnswersDtoModel answer)
            {
            _context.answer.Add(answer);
            _context.SaveChanges();
            }
        }
    }
