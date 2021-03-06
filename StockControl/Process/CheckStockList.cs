﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using Telerik.WinControls.UI;
using System.Globalization;

namespace StockControl
{
    public partial class CheckStockList : Telerik.WinControls.UI.RadRibbonForm
    {
        public CheckStockList()
        {
            this.Name = "CheckStockList";
            InitializeComponent();
        }

        //private int RowView = 50;
        //private int ColView = 10;
        DataTable dt = new DataTable();
        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            HistoryView hw = new HistoryView(this.Name);
            this.Cursor = Cursors.Default;
            hw.ShowDialog();
        }

        private void radRibbonBar1_Click(object sender, EventArgs e)
        {

        }
        private void GETDTRow()
        {
            dt.Columns.Add(new DataColumn("edit", typeof(bool)));
            dt.Columns.Add(new DataColumn("code", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Active", typeof(bool)));
            dt.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("CreateBy", typeof(string)));
        }
        private void Unit_Load(object sender, EventArgs e)
        {
            //RMenu3.Click += RMenu3_Click;
            //RMenu4.Click += RMenu4_Click;
            //RMenu5.Click += RMenu5_Click;
            RMenu6.Click += RMenu6_Click;
            // radGridView1.ReadOnly = true;
            dgvData.AutoGenerateColumns = false;
            //GETDTRow();
           
            
            //DataLoad();
        }

        private void RMenu6_Click(object sender, EventArgs e)
        {
           
            DeleteUnit();
            LoadDefault();
        }

        private void RMenu5_Click(object sender, EventArgs e)
        {
            EditClick();
        }

        private void RMenu4_Click(object sender, EventArgs e)
        {
            ViewClick();
        }

        private void RMenu3_Click(object sender, EventArgs e)
        {
            NewClick();

        }

        private void DataLoad()
        {
            
            int ck = 0;
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {

                dgvData.DataSource = db.tb_CheckStocks.ToList();
                foreach (var x in dgvData.Rows)
                {

                   // x.Cells["dgvCodeTemp"].Value = x.Cells["UnitCode"].Value.ToString();
                  //  x.Cells["UnitCode"].ReadOnly = true;
                    //if (row >= 0 && row == ck && radGridView1.Rows.Count > 0)
                    //{

                    //    x.ViewInfo.CurrentRow = x;

                    //}
                    ck += 1;
                    x.Cells["No"].Value = ck;
                }

            }


            
        }
        private bool CheckDuplicate(string code)
        {
            bool ck = false;

            //using (DataClasses1DataContext db = new DataClasses1DataContext())
            //{
            //    int i = (from ix in db.tb_Units where ix.UnitCode == code select ix).Count();
            //    if (i > 0)
            //        ck = false;
            //    else
            //        ck = true;
            //}
            return ck;
        }

        private bool AddUnit()
        {
            bool ck = false;
            //int C = 0;
            //try
            //{


            //    radGridView1.EndEdit();
            //    using (DataClasses1DataContext db = new DataClasses1DataContext())
            //    {
            //        foreach (var g in radGridView1.Rows)
            //        {
            //            if (!Convert.ToString(g.Cells["UnitCode"].Value).Equals(""))
            //            {
            //                if (Convert.ToString(g.Cells["dgvC"].Value).Equals("T"))
            //                {
                               
            //                    if (Convert.ToString(g.Cells["dgvCodeTemp"].Value).Equals(""))
            //                    {
            //                       // MessageBox.Show("11");
                                    
            //                        tb_Unit u = new tb_Unit();
            //                        u.UnitCode = Convert.ToString(g.Cells["UnitCode"].Value);
            //                        u.UnitActive = Convert.ToBoolean(g.Cells["UnitActive"].Value);
            //                        u.UnitDetail= Convert.ToString(g.Cells["UnitDetail"].Value);
            //                        db.tb_Units.InsertOnSubmit(u);
            //                        db.SubmitChanges();
            //                        C += 1;
            //                        dbClss.AddHistory(this.Name, "เพิ่ม", "Insert Unit Code [" + u.UnitCode+"]","");
            //                    }
            //                    else
            //                    {
                                   
            //                        var unit1 = (from ix in db.tb_Units
            //                                     where ix.UnitCode == Convert.ToString(g.Cells["dgvCodeTemp"].Value)
            //                                     select ix).First();
            //                           unit1.UnitDetail = Convert.ToString(g.Cells["UnitDetail"].Value);
            //                           unit1.UnitActive = Convert.ToBoolean(g.Cells["UnitActive"].Value);
                                    
            //                        C += 1;

            //                        db.SubmitChanges();
            //                        dbClss.AddHistory(this.Name, "แก้ไข", "Update Unit Code [" + unit1.UnitCode+"]","");

            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message);
            //    dbClss.AddError("AddUnit", ex.Message, this.Name);
            //}

            //if (C > 0)
            //    MessageBox.Show("บันทึกสำเร็จ!");

            return ck;
        }
        private bool DeleteUnit()
        {
            bool ck = false;
            this.Cursor = Cursors.WaitCursor;
            int C = 0;
            try
            {

                if (row >= 0)
                {
                    string CheckNo = Convert.ToString(dgvData.Rows[row].Cells["CheckNo"].Value);
                  //  string CodeTemp = Convert.ToString(radGridView1.Rows[row].Cells["dgvCodeTemp"].Value);
                    dgvData.EndEdit();
                    if (MessageBox.Show("ต้องการลบรายการ ( " + CheckNo + " ) หรือไม่ ?", "ลบรายการ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (DataClasses1DataContext db = new DataClasses1DataContext())
                        {
                            tb_CheckStock cd = db.tb_CheckStocks.Where(c => c.CheckNo == CheckNo && !c.Status.Equals("Completed")).FirstOrDefault();
                            if (cd != null)
                            {
                                db.tb_CheckStocks.DeleteOnSubmit(cd);
                                var DeleteStockList = db.tb_CheckStockLists.Where(s => s.CheckNo == CheckNo).ToList();
                               // db.tb_CheckStockLists.DeleteAllOnSubmit(DeleteStockList);
                                foreach(var rd in DeleteStockList)
                                {
                                    db.tb_CheckStockLists.DeleteOnSubmit(rd);
                                    //db.SubmitChanges();
                                }
                                db.SubmitChanges();
                                
                                C = 1;
                                dbClss.AddHistory(this.Name, "ลบรายการ", "Delete Check No [" + CheckNo + "]", "");
                            }

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dbClss.AddError("DeleteUnit", ex.Message, this.Name);
            }

            if (C > 0)
            {
                row = row - 1;
                MessageBox.Show("ลบรายการ สำเร็จ!");
            }
            this.Cursor = Cursors.Default;



            return ck;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataLoad();
        }
        private void NewClick()
        {
            //radGridView1.ReadOnly = false;
            //radGridView1.AllowAddNewRow = false;
            ////btnEdit.Enabled = false;
            //btnView.Enabled = true;
            //radGridView1.Rows.AddNew();
        }
        private void EditClick()
        {
            //radGridView1.ReadOnly = false;
            ////btnEdit.Enabled = false;
            //btnView.Enabled = true;
            //radGridView1.AllowAddNewRow = false;
        }
        private void ViewClick()
        {
           //// radGridView1.ReadOnly = true;
           // btnView.Enabled = false;
           // //btnEdit.Enabled = true;
           // radGridView1.AllowAddNewRow = false;
           // DataLoad();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewClick();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            EditClick();
        }
        private void Saveclick()
        {
            if (MessageBox.Show("ต้องการสร้าง List สำหรับเช็ค Stock ?", "สร้าง List", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (DataClasses1DataContext db = new DataClasses1DataContext())
                    {
                        tb_CheckStock cl = db.tb_CheckStocks.Where(c => !c.Status.Equals("Completed")).FirstOrDefault();
                        if (cl != null)
                        {
                            MessageBox.Show("เลขเช็คสต๊อค เก่ายังไม่ได้ ปิดสถานะ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            tb_CheckStock list1 = new tb_CheckStock();
                            list1.CheckNo = dbClss.GetSeriesNo(1, 2);
                            list1.CreateBy = dbClss.UserID;
                            list1.CheckDate = DateTime.Now;
                            list1.Status = "Waiting Upload";
                            db.tb_CheckStocks.InsertOnSubmit(list1);
                            db.SubmitChanges();
                            LoadDefault();
                        }
                    }

                }
                catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  }
            }
        }
        private void DeleteClick()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Saveclick();
        }


        private void radGridView1_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                //radGridView1.Rows[e.RowIndex].Cells["dgvC"].Value = "T";
                //string check1 = Convert.ToString(radGridView1.Rows[e.RowIndex].Cells["UnitCode"].Value);
                //string TM= Convert.ToString(radGridView1.Rows[e.RowIndex].Cells["dgvCodeTemp"].Value);
                //if (!check1.Trim().Equals("") && TM.Equals(""))
                //{
                    
                //    if (!CheckDuplicate(check1.Trim()))
                //    {
                //        MessageBox.Show("ข้อมูล รหัสหน่วย ซ้ำ");
                //        radGridView1.Rows[e.RowIndex].Cells["UnitCode"].Value = "";
                //        radGridView1.Rows[e.RowIndex].Cells["UnitCode"].IsSelected = true;

                //    }
                //}
        

            }
            catch(Exception ex) { }
        }

        private void Unit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {


        }

        private void radGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            //if (e.KeyData == (Keys.Control | Keys.S))
            //{
            //    if (MessageBox.Show("ต้องการบันทึก ?", "บันทึก", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        AddUnit();
            //        DataLoad();
            //    }
            //}
            //else if (e.KeyData == (Keys.Control | Keys.N))
            //{
            //    if (MessageBox.Show("ต้องการสร้างใหม่ ?", "สร้างใหม่", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        NewClick();
            //    }
            //}

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
                DeleteUnit();
                DataLoad();
            
        }

        int row = -1;
        private void radGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //dbClss.ExportGridCSV(radGridView1);
           dbClss.ExportGridXlSX(dgvData);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Spread Sheet files (*.csv)|*.csv|All files (*.csv)|*.csv";
            if (op.ShowDialog() == DialogResult.OK)
            {


                using (TextFieldParser parser = new TextFieldParser(op.FileName))
                {
                    dt.Rows.Clear();
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int a = 0;
                    int c = 0;
                    while (!parser.EndOfData)
                    {
                        //Processing row
                        a += 1;
                        DataRow rd = dt.NewRow();
                        // MessageBox.Show(a.ToString());
                        string[] fields = parser.ReadFields();
                        c = 0;
                        foreach (string field in fields)
                        {
                            c += 1;
                            //TODO: Process field
                            //MessageBox.Show(field);
                            if (a>1)
                            {
                                if(c==1)
                                    rd["UnitCode"] = Convert.ToString(field);
                                else if(c==2)
                                    rd["UnitDetail"] = Convert.ToString(field);
                                else if(c==3)
                                    rd["UnitActive"] = Convert.ToBoolean(field);

                            }
                            else
                            {
                                if (c == 1)
                                    rd["UnitCode"] = "";
                                else if (c == 2)
                                    rd["UnitDetail"] = "";
                                else if (c == 3)
                                    rd["UnitActive"] = false;




                            }

                            //
                            //rd[""] = "";
                            //rd[""]
                        }
                        dt.Rows.Add(rd);

                    }
                }
                if(dt.Rows.Count>0)
                {
                    dbClss.AddHistory(this.Name, "Import", "Import file CSV in to System", "");
                    ImportData();
                    MessageBox.Show("Import Completed.");

                    DataLoad();
                }
               
            }
        }

        private void ImportData()
        {
            //try
            //{
            //    using (DataClasses1DataContext db = new DataClasses1DataContext())
            //    {
                   
            //        foreach (DataRow rd in dt.Rows)
            //        {
            //            if (!rd["UnitCode"].ToString().Equals(""))
            //            {

            //                var x = (from ix in db.tb_Units where ix.UnitCode.ToLower().Trim() == rd["UnitCode"].ToString().ToLower().Trim() select ix).FirstOrDefault();

            //                if(x==null)
            //                {
            //                    tb_Unit ts = new tb_Unit();
            //                    ts.UnitCode = Convert.ToString(rd["UnitCode"].ToString());
            //                    ts.UnitDetail = Convert.ToString(rd["UnitDetail"].ToString());
            //                    ts.UnitActive = Convert.ToBoolean(rd["UnitActive"].ToString());
            //                    db.tb_Units.InsertOnSubmit(ts);
            //                    db.SubmitChanges();
            //                }
            //                else
            //                {
            //                    x.UnitDetail = Convert.ToString(rd["UnitDetail"].ToString());
            //                    x.UnitActive = Convert.ToBoolean(rd["UnitActive"].ToString());
            //                    db.SubmitChanges();

            //                }

                       
            //            }
            //        }
                   
            //    }
            //}
            //catch(Exception ex) { MessageBox.Show(ex.Message);
            //    dbClss.AddError("InportData", ex.Message, this.Name);
            //}
        }

        private void btnFilter1_Click(object sender, EventArgs e)
        {
            dgvData.EnableFiltering = true;
        }

        private void btnUnfilter1_Click(object sender, EventArgs e)
        {
            dgvData.EnableFiltering = false;
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radButtonElement2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "excel files (*.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void CheckStockList_Load(object sender, EventArgs e)
        {
            RMenu6.Click += RMenu6_Click;
             dgvData.ReadOnly = true;
            dgvData.AutoGenerateColumns = false;
            LoadDefault();

        }

        private void LoadDefault()
        {
            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    dgvData.AutoGenerateColumns = false;
                    dgvData.ReadOnly = true;   
                    var ListData = db.tb_CheckStocks.Where(ck => ck.Status != "Deleted").ToList();
                    dgvData.DataSource = ListData;
                    int rowNo = 0;
                    foreach(GridViewRowInfo rd in dgvData.Rows)
                    {
                        rd.Cells["No"].Value = rowNo + 1;
                        rowNo += 1;
                    }

                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void radButtonElement2_Click_1(object sender, EventArgs e)
        {
            //Call Screen Upload from TPICS

            if (dgvData.Rows.Count <= 0)
                return;

            string CheckNo = "";
            if(dbClss.TSt(dgvData.CurrentRow.Cells["CheckNo"].Value) == "Completed")
            {
                MessageBox.Show("สถานะไม่ถูกต้อง");
                return;
            }
            CheckNo = dbClss.TSt(dgvData.CurrentRow.Cells["CheckNo"].Value);

            try
            {
                CheckStockUpload a = new CheckStockUpload(CheckNo);
                a.ShowDialog();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            /////////////////////////////////
        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.Rows.Count <= 0)
                    return;
                //ReportCheckStock.rpt
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    string CheckNo = dbClss.TSt(dgvData.CurrentRow.Cells["CheckNo"].Value);

                    var g = (from ix in db.sp_R_001_Report_CheckStock(CheckNo, CheckNo,Convert.ToDateTime(DateTime.Now, new CultureInfo("en-US"))) select ix).ToList();
                    if (g.Count() > 0)
                    {
                        Report.Reportx1.Value = new string[2];
                        Report.Reportx1.Value[0] = CheckNo;
                        Report.Reportx1.Value[1] = CheckNo;
                        Report.Reportx1.WReport = "ReportCheckStock";
                        Report.Reportx1 op = new Report.Reportx1("ReportCheckStock.rpt");
                        op.Show();
                    }
                    else
                        MessageBox.Show("not found.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvData_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (row >= 0)
            {
                string ckNo = dgvData.Rows[row].Cells["CheckNo"].Value.ToString();
                CheckStock ck = new CheckStock(ckNo);
                ck.ShowDialog();
            }
        }

        private void radButtonElement3_Click(object sender, EventArgs e)
        {
            DeleteUnit();
            LoadDefault();
        }
    }
}
