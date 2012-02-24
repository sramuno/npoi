
/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is1 distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */



namespace TestCases.HSSF.Record.Chart
{
    using System;
    using NPOI.HSSF.Record;
    using NPOI.HSSF.Record.Chart;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /**
     * Tests the serialization and deserialization of the ObjectLinkRecord
     * class works correctly.  Test data taken directly from a real
     * Excel file.
     *

     * @author Andrew C. Oliver (acoliver at apache.org)
     */
    [TestClass]
    public class TestObjectLinkRecord
    {
        byte[] data = new byte[] {
	(byte)0x03,(byte)0x00,(byte)0x00,(byte)0x00,(byte)0x00,(byte)0x00
    };

        public TestObjectLinkRecord()
        {

        }
        [TestMethod]
        public void TestLoad()
        {
            ObjectLinkRecord record = new ObjectLinkRecord(TestcaseRecordInputStream.Create((short)0x1027, data));


            Assert.AreEqual((short)3, record.AnchorId);

            Assert.AreEqual((short)0x00, record.Link1);

            Assert.AreEqual((short)0x00, record.Link2);


            Assert.AreEqual(10, record.RecordSize);
        }
        [TestMethod]
        public void TestStore()
        {
            ObjectLinkRecord record = new ObjectLinkRecord();



            record.AnchorId=((short)3);

            record.Link1=((short)0x00);

            record.Link2=((short)0x00);


            byte[] recordBytes = record.Serialize();
            Assert.AreEqual(recordBytes.Length - 4, data.Length);
            for (int i = 0; i < data.Length; i++)
                Assert.AreEqual(data[i], recordBytes[i + 4], "At offset " + i);
        }
    }
}