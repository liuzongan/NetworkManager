/* Copyright (c) 2013 ETH Zurich
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Runtime.Serialization;

namespace FIcontent.Gaming.Enabler.GameSynchronization.Packets.Actions
{
    /// <summary>
    /// Abstracts a serializable action
    /// </summary>
    [Serializable]
    public abstract class AbstractAction : ISerializable, IAction
    {
        /// <summary>
        /// Generic constructor
        /// </summary>
        /// <param name="action">the type of the action must be specified</param>
        public AbstractAction(int actionType)
        {
            this.Action = actionType;
        }

        /// <summary>
        /// This constructor is used by deserialization
        /// </summary>        
        public AbstractAction(SerializationInfo info, StreamingContext context)
        {
            ObjectID = info.GetInt32("objID");
            Action = info.GetInt32("action");
            GUID = info.GetString("guid");
        }

        #region IAction members

        public int ObjectID { get; set; }
        public int Action { get; set; }
        public string GUID { get; set; }
     
        #endregion
             
        #region ISerializable members
               
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("objID", ObjectID);
            info.AddValue("action", Action);
            info.AddValue("guid", GUID);     
        }

        #endregion
    }
}
