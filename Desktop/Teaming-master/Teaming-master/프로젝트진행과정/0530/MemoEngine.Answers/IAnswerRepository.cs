using System;
using System.Collections.Generic;
using System.Text;

namespace MemoEngine.Answers
{
    public interface IAnswerRepository : IBreadShop<Answer>
    {   
        int Delete(int id, string password);

        List<Answer> GetAnswers(int padgeNumber, int pageSize = 10);

        int GetCountAll();

        int GetCountBySearch(string searchField, string searchQuery);

        List<Answer> GetSearchAll(string searchField, string searchQuery, int pageNumber, int pageSize = 10);

        List<Answer> GetSummaryByCategory(string category);

        string GetFileNameById(int id);

        List<Answer> GetNewPhotos();

        Answer GetById(int id);

        List<Answer> GetRecentPosts(int number = 5);

        void Pinned(int id); // 특정 번호 고정 시키기 (공지 글 등)

        void ReplyModel(Answer model);

        int SaveOrUpdate(Answer n, BoardWriteFormType formType);

        void UpdateDownCount(string fileName);

        void UpdateDownCountById(int id);

        int UpdateModel(Answer model);

        Answer WriteModel(Answer model);
    }
}
