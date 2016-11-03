using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IBatisNet.DataAccess.Exceptions;
using IBatisNet.DataMapper.Exceptions;
using EntityModel;

namespace CustomerPersistence_PI
{
    /// <summary>
    /// Summary description for SequenceSqlMapDao.
    /// </summary>
    public class SequenceSqlMapDao : BaseMapDao, ISequenceDao
    {

        #region ISequenceDao Members

        /// <summary>
        /// This is a generic sequence ID generator that is based on a database
        /// table called 'SEQUENCE', which contains two columns (NAME, NEXTID).
        /// </summary>
        /// <param name="name">name The name of the sequence.</param>
        /// <returns>The Next ID</returns>
        public int GetNextId(string name)
        {
            Sequence sequence = new Sequence(name, -1);

            sequence = ExecuteQueryForObject("GetSequence", sequence) as Sequence;
            if (sequence == null)
            {
                throw new DataMapperException("Error: A null sequence was returned from the database (could not get next " + name + " sequence).");
            }
            object parameterObject = new Sequence(name, sequence.NextId + 1);
            ExecuteUpdate("UpdateSequence", parameterObject);

            return sequence.NextId;
        }

        #endregion
    }
}
