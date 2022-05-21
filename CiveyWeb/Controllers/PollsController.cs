
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiveyWeb.Database;
using CiveyWeb.Database.DbModels;
using CiveyWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CiveyWeb.Controllers
    {
    [ApiController]
    [Route("[controller]")]
    public class PollsController : ControllerBase
        {

        private readonly IDataAccessProvider _dataAccessProvider;

        public PollsController(IDataAccessProvider dataAccessProvider)
            {
            _dataAccessProvider = dataAccessProvider;
            }
        [HttpGet("{pageNumber?}/{pageSize?}")]
        public async Task<IEnumerable<PollModel>> Get(int pageNumber, int pageSize)
            {
            List<PollModel> lstpolls = new List<PollModel>();
            List<PollDtoModel> pollDtoModel = _dataAccessProvider.GetPollRecordsByPageNumberAndPageSize(pageNumber, pageSize);

            foreach (var item in pollDtoModel)
                {

                List<AnswersDtoModel> answerDtoModels = _dataAccessProvider.GetAnswerRecordByPollId(item.id);

                List<AnswerModel> lstanswer = new List<AnswerModel>();

                foreach (var answerModel in answerDtoModels)
                    {
                    lstanswer.Add(new AnswerModel { Id = answerModel.id, Text = answerModel.text });
                    }


                lstpolls.Add(
                    new PollModel
                        {
                        Id = item.id,
                        Text = item.text,
                        MultiChoice = item.multi_choice,
                        Answers = lstanswer

                        }
                    );
                }

            return lstpolls;

            }


        [HttpGet("poll/{searchpoll}")]
        public async Task<IEnumerable<PollModel>> GetBySearchingPolls(string  searchpoll)
            {
            List<PollModel> lstpolls = new List<PollModel>();
            List<PollDtoModel> pollDtoModel = _dataAccessProvider.GetPollRecordsBySearchingPolls(searchpoll);

            foreach (var item in pollDtoModel)
                {

                List<AnswersDtoModel> answerDtoModels = _dataAccessProvider.GetAnswerRecordByPollId(item.id);

                List<AnswerModel> lstanswer = new List<AnswerModel>();

                foreach (var answerModel in answerDtoModels)
                    {
                    lstanswer.Add(new AnswerModel { Id = answerModel.id, Text = answerModel.text });
                    }


                lstpolls.Add(
                    new PollModel
                        {
                        Id = item.id,
                        Text = item.text,
                        MultiChoice = item.multi_choice,
                        Answers = lstanswer

                        }
                    );
                }

            return lstpolls;

            }


        [HttpGet("ans/{searchanswers}")]
        public async Task<IEnumerable<PollModel>> GetBySearchingAnswers(string searchanswers)
            {
            List<PollModel> lstpolls = new List<PollModel>();
            List<PollDtoModel> pollDtoModel = _dataAccessProvider.GetPollRecordsByAnsers(searchanswers);

            foreach (var item in pollDtoModel)
                {

                List<AnswersDtoModel> answerDtoModels = _dataAccessProvider.GetAnswerRecordByPollId(item.id);

                List<AnswerModel> lstanswer = new List<AnswerModel>();

                foreach (var answerModel in answerDtoModels)
                    {
                    lstanswer.Add(new AnswerModel { Id = answerModel.id, Text = answerModel.text });
                    }


                lstpolls.Add(
                    new PollModel
                        {
                        Id = item.id,
                        Text = item.text,
                        MultiChoice = item.multi_choice,
                        Answers = lstanswer

                        }
                    );
                }

            return lstpolls;

            }


        [HttpGet("{id}")]

        public async Task<PollModel> Get(int id)
            {
            PollDtoModel pollDtoModel = _dataAccessProvider.GetPollRecordById(id);

            List<AnswersDtoModel> answerDtoModels = _dataAccessProvider.GetAnswerRecordByPollId(id);

            List<AnswerModel> lstanswer = new List<AnswerModel>();

            foreach (var answerModel in answerDtoModels)
                {
                lstanswer.Add(new AnswerModel { Id = answerModel.id, Text = answerModel.text });
                }


            PollModel pollModel = new PollModel
                {
                Id = pollDtoModel.id,
                Text = pollDtoModel.text,
                MultiChoice = pollDtoModel.multi_choice,
                Answers = lstanswer
                };

            return pollModel;
            }





        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PollModel pollModel)
            {
            try
                {

                PollDtoModel pollDto = new PollDtoModel
                    {
                    id = pollModel.Id,
                    text = pollModel.Text,
                    multi_choice = pollModel.MultiChoice
                    };

                _dataAccessProvider.AddPollRecord(pollDto);

                foreach (var answer in pollModel.Answers)
                    {
                    AnswersDtoModel answersDtoModel = new AnswersDtoModel
                        {
                        id = answer.Id,
                        poll_id = pollModel.Id,
                        text = answer.Text
                        };

                    _dataAccessProvider.AddAnswerRecord(answersDtoModel);

                    }
                return Ok();
                }
            catch(Exception ex)
                {
                return StatusCode(StatusCodes.Status500InternalServerError);
                } 
            }


        }
    }