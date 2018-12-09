using System.Collections;
using Entities.Models;

namespace Entities.Seeders
{
    public static class General
    {
        //  Up changes to database
        public static void Up()
        {
            //  Definitions
            string[] category_fields, lesson_fields, question_fields, answer_fields;
            CategoryModel category;
            LessonModel lesson;
            QuestionModel question;
            AnswerModel answer;

            //  Declarations
            category = new CategoryModel();
            lesson = new LessonModel();
            question = new QuestionModel();
            answer = new AnswerModel();

            //  Assign category, lesson, question and answer fields
            category_fields = new string[] {
                "name_ES",
                "name_EN",
                "description_ES",
                "description_EN",
                "enviroment_name"
            };
            lesson_fields = new string[] {
                "name_ES",
                "name_EN",
                "description_ES",
                "description_EN",
                "scene_name",
                "category_id"
            };
            question_fields = new string[] {
                "question_text_ES",
                "question_text_EN",
                "lesson_id"
            };
            answer_fields = new string[] {
                "answer_text_ES",
                "answer_text_EN",
                "is_correct",
                "question_id"
            };

            //  Process
            //  Add category
            category.Insert(
                category_fields,
                new string[] {
                    "Escenario 1",
                    "Stage 1",
                    "Es el escenario 1",
                    "It is a stage 1",
                    "Stage_1"
                });
            //  Add lesson
            lesson.Insert(
                lesson_fields,
                new string[] {
                    "Nivel 1",
                    "Level 1",
                    "Es el nivel 1",
                    "It is a level 1",
                    "Level_1",
                    "1"
                });
            //  Add question
            question.Insert(
                question_fields,
                new string[] {
                    "¿Dónde se está la pelota?",
                    "Where are the ball?",
                    "1"
                });
            //  Add answer
            answer.Insert(
                answer_fields,
                new string[] {
                    "Pasto",
                    "Grass",
                    "0",
                    "1"
                });
            answer.Insert(
                answer_fields,
                new string[] {
                    "Banca",
                    "Bank",
                    "0",
                    "1"
                });
            answer.Insert(
                answer_fields,
                new string[] {
                    "Pino",
                    "Pine tree",
                    "1",
                    "1"
                });
        }

        //  Down all changes to database in Up function
        public static void Down()
        {
            //  Definitions
            CategoryModel category;
            LessonModel lesson;
            QuestionModel question;
            AnswerModel answer;
            ScoreModel score;
            UserModel user;

            //  Declarations
            category = new CategoryModel();
            lesson = new LessonModel();
            question = new QuestionModel();
            answer = new AnswerModel();
            score = new ScoreModel();
            user = new UserModel();

            //  Process
            score.Delete();
            user.Delete();
            category.Delete();
            lesson.Delete();
            question.Delete();
            answer.Delete();
        }
    }

}