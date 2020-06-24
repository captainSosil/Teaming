using System;
using System.Collections.Generic;

// 실제 구현해야 하는 클래스들

namespace MemoEngine.Answers
{
    class AnswerCommentRepository : IAnswerCommentRepository
    {
        public AnswerComment Add(AnswerComment model)
        {
            throw new NotImplementedException();
        }

        public void AddComment(AnswerComment model)
        {
            throw new NotImplementedException();
        }

        public AnswerComment Browse(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteComment(int articleId, int id, string password)
        {
            throw new NotImplementedException();
        }

        public bool Edit(AnswerComment model)
        {
            throw new NotImplementedException();
        }

        public List<AnswerComment> GetComments(int articleId)
        {
            throw new NotImplementedException();
        }

        public int GetCountBy(int articleId, int id, string password)
        {
            throw new NotImplementedException();
        }

        public List<AnswerComment> GetRecentComments()
        {
            throw new NotImplementedException();
        }

        public int Has()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AnswerComment> Ordering(OrderOption orderOption)
        {
            throw new NotImplementedException();
        }

        public List<AnswerComment> Paging(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List<AnswerComment> Read()
        {
            throw new NotImplementedException();
        }

        public List<AnswerComment> Search(string query)
        {
            throw new NotImplementedException();
        }
    }
}
