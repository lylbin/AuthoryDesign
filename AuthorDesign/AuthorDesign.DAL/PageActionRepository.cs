﻿using AuthorDesign.IDAL;
using AuthorDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorDesign.DAL {
    public class PageActionRepository : BaseRepository<PageAction>, IPageActionRepository {
        /// <summary>
        /// 获取页面按钮列表
        /// </summary>
        /// <param name="startNum">起始数字</param>
        /// <param name="pageSize">页长</param>
        /// <param name="isDesc">是否倒叙排序</param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public IQueryable<PageAction> LoadPageList(int startNum, int pageSize, bool isDesc, out int rowCount) {
            rowCount = 0;
            var result = from p in db.Set<PageAction>()
                         select p;
            if (isDesc) {
                result = result.OrderByDescending(m => m.ActionLevel);
            }
            else {
                result = result.OrderBy(m => m.ActionLevel);
            }
            rowCount = result.Count();
            return result.Skip(startNum).Take(pageSize);
        }
    }
}
