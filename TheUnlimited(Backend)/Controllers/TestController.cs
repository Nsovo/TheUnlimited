using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using TheUnlimited_Backend_.Models;
using Microsoft.Extensions.Logging;

namespace TheUnlimited_Backend_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TestController> _logger;

        public TestController(AppDbContext context, ILogger<TestController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Test
        [HttpGet]
        public IActionResult GetTestsForUser(int agentID)
        {
            var agent = _context.Agents
                .FirstOrDefault(a => a.AgentID == agentID);

            if (agent == null)
            {
                _logger.LogWarning("Agent with ID {AgentID} not found", agentID);
                return BadRequest("Agent not found");
            }

            var tests = _context.Tests
                .Where(t => t.TestAccesses.Any(ta => ta.AgentLevelID == agent.AgentLevelID))
                .ToList();

            if (!tests.Any())
            {
                _logger.LogWarning("No tests available for agent level {AgentLevelID}", agent.AgentLevelID);
                return NotFound("No tests available for your level");
            }

            return Ok(tests);
        }

        // GET: api/Test/Questions
        [HttpGet("Questions")]
        public IActionResult GetTestQuestionsForUser(int agentID)
        {
            var agent = _context.Agents
                .FirstOrDefault(a => a.AgentID == agentID);

            if (agent == null)
            {
                _logger.LogWarning("Agent with ID {AgentID} not found", agentID);
                return BadRequest("Agent not found");
            }

            var test = _context.Tests
                .FirstOrDefault(t => t.TestAccesses.Any(ta => ta.AgentLevelID == agent.AgentLevelID));

            if (test == null)
            {
                _logger.LogWarning("No test available for agent level {AgentLevelID}", agent.AgentLevelID);
                return NotFound("No test available for your level");
            }

            var testQuestions = _context.TestQuestions
                .Where(tq => tq.TestID == test.TestID)
                .ToList();

            var result = testQuestions.Select(tq => new
            {
                tq.TestQuestionID,
                tq.QuestionText,
                Answers = _context.TestAnswers
                    .Where(ta => ta.TestQuestionID == tq.TestQuestionID)
                    .Select(ta => new { ta.TestAnswerID, ta.AnswerText })
                    .Concat(_context.TestWrongAnswers
                        .Where(twa => twa.TestQuestionID == tq.TestQuestionID)
                        .Select(twa => new { TestAnswerID = -twa.TestWrongAnswerID, AnswerText = twa.WrongAnswerText }))
                    .OrderBy(_ => System.Guid.NewGuid()) // Randomize answers
                    .ToList()
            });

            return Ok(result);
        }

        [HttpPost("Submit")]
        public IActionResult SubmitTest([FromBody] TestSubmissionModel submission)
        {
            try
            {
                _logger.LogInformation("Received test submission: {@Submission}", submission);

                // Validate submission data
                if (submission == null || submission.TestID == 0 || submission.AgentID == 0 || submission.Answers == null || !submission.Answers.Any())
                {
                    _logger.LogWarning("Invalid submission data: {@Submission}", submission);
                    return BadRequest("Invalid submission data");
                }

                // Verify agent existence
                var agent = _context.Agents.FirstOrDefault(a => a.AgentID == submission.AgentID);
                if (agent == null)
                {
                    _logger.LogWarning("Agent with ID {AgentID} not found", submission.AgentID);
                    return BadRequest("Agent not found");
                }

                // Check if the agent has access to the test based on their level
                var hasAccess = _context.Tests.Any(t => t.TestID == submission.TestID && t.TestAccesses.Any(ta => ta.AgentLevelID == agent.AgentLevelID));
                if (!hasAccess)
                {
                    _logger.LogWarning("Agent with ID {AgentID} does not have access to test ID {TestID}", submission.AgentID, submission.TestID);
                    return Forbid("You do not have access to this test");
                }

                // Process submitted answers
                var correctAnswersCount = 0;
                foreach (var answer in submission.Answers)
                {
                    _logger.LogInformation("Processing answer: {@Answer}", answer);

                    var correctAnswer = _context.TestAnswers.FirstOrDefault(ta => ta.TestAnswerID == answer.TestAnswerID && ta.IsCorrect);
                    if (correctAnswer != null)
                    {
                        correctAnswersCount++;
                    }
                    else
                    {
                        _logger.LogWarning("Invalid or incorrect answer: {@Answer}", answer);
                    }
                }

                // Calculate pass/fail result
                var passThreshold = 0.7; // 70% correct answers to pass
                var totalQuestions = _context.TestQuestions.Count(tq => tq.TestID == submission.TestID);
                var passed = correctAnswersCount >= totalQuestions * passThreshold;

                // Update agent level if they passed
                if (passed)
                {
                    if (agent.AgentLevelID == 1)
                        agent.AgentLevelID = 2;
                    else if (agent.AgentLevelID == 2)
                        agent.AgentLevelID = 3;
                    else if (agent.AgentLevelID == 3)
                        agent.AgentLevelID = 4;

                    _context.SaveChanges();
                }

                _logger.LogInformation("Test submission processed: Passed={Passed}, CorrectAnswersCount={CorrectAnswersCount}, TotalQuestions={TotalQuestions}", passed, correctAnswersCount, totalQuestions);

                // Return result
                return Ok(new { Passed = passed, Score = (correctAnswersCount / (double)totalQuestions) * 100 });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing test submission");
                return StatusCode(500, "Internal server error");
            }
        }
    }

    public class TestSubmissionModel
    {
        public int TestID { get; set; }
        public int AgentID { get; set; }
        public List<AnswerSubmissionModel> Answers { get; set; }
    }

    public class AnswerSubmissionModel
    {
        public int TestAnswerID { get; set; }
    }
}
