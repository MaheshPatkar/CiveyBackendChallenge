using CiveyWeb.Database.DbModels ;  
using System.Collections.Generic;  
  
namespace CiveyWeb.Database
    {
    public interface IDataAccessProvider
        {
        List<PollDtoModel> GetPollRecords();

        List<PollDtoModel> GetPollRecordsByPageNumberAndPageSize(int pageNumber,int pageSize);

        List<PollDtoModel> GetPollRecordsBySearchingPolls(string searchText);

        List<PollDtoModel> GetPollRecordsByAnsers(string searchText);

        PollDtoModel GetPollRecordById(int id);

        void AddPollRecord(PollDtoModel poll);

        List<AnswersDtoModel> GetAnswerRecords();

        List<AnswersDtoModel> GetAnswerRecordByPollId(long pollId);

        void AddAnswerRecord(AnswersDtoModel answer);
        }


    }
