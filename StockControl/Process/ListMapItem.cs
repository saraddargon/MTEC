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
namespace StockControl
{
    public partial class ListMapItem : Telerik.WinControls.UI.RadRibbonForm
    {
        public ListMapItem()
        {
            this.Name = "ListMapItem";
            if (!dbClss.PermissionScreen(this.Name))
            {
                MessageBox.Show("Access denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
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
            //dt.Columns.Add(new DataColumn("edit", typeof(bool)));
            //dt.Columns.Add(new DataColumn("code", typeof(string)));
            //dt.Columns.Add(new DataColumn("Name", typeof(string)));
            //dt.Columns.Add(new DataColumn("Active", typeof(bool)));
            //dt.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
            //dt.Columns.Add(new DataColumn("CreateBy", typeof(string)));
        }
        private void Unit_Load(object sender, EventArgs e)
        {
            //RMenu3.Click += RMenu3_Click;
            //RMenu4.Click += RMenu4_Click;
            //RMenu5.Click += RMenu5_Click;
            //RMenu6.Click += RMenu6_Click;
            // radGridView1.ReadOnly = true;
           
            radGridView1.AutoGenerateColumns = false;
           // GETDTRow();
           
            
            DataLoad();
        }

        private void RMenu6_Click(object sender, EventArgs e)
        {
           
            //DeleteUnit();
            //DataLoad();
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
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int ck = 0;
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {

                    radGridView1.DataSource = db.sp_005_TPIC_SelectMapping(txtItemNo.Text).ToList();
                    foreach (var x in radGridView1.Rows)
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
            catch { }
            this.Cursor = Cursors.Default;



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
         
            //int C = 0;
            //try
            //{
                
            //    if (row >= 0)
            //    {
            //        string CodeDelete = Convert.ToString(radGridView1.Rows[row].Cells["UnitCode"].Value);
            //        string CodeTemp = Convert.ToString(radGridView1.Rows[row].Cells["dgvCodeTemp"].Value);
            //        radGridView1.EndEdit();
            //        if (MessageBox.Show("ต้องการลบรายการ ( "+ CodeDelete+" ) หรือไม่ ?", "ลบรายการ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            using (DataClasses1DataContext db = new DataClasses1DataContext())
            //            {

            //                if (!CodeDelete.Equals(""))
            //                {
            //                    if (!CodeTemp.Equals(""))
            //                    {

            //                        var unit1 = (from ix in db.tb_Units
            //                                     where ix.UnitCode == CodeDelete
            //                                     select ix).ToList();
            //                        foreach (var d in unit1)
            //                        {
            //                            db.tb_Units.DeleteOnSubmit(d);
            //                            dbClss.AddHistory(this.Name, "ลบ Unit", "Delete Unit Code ["+d.UnitCode+"]","");
            //                        }
            //                        C += 1;



            //                        db.SubmitChanges();
            //                    }
            //                }

            //            }
            //        }
            //    }
            //}

            //catch (Exception ex) { MessageBox.Show(ex.Message);
            //    dbClss.AddError("DeleteUnit", ex.Message, this.Name);
            //}

            //if (C > 0)
            //{
            //        row = row - 1;
            //        MessageBox.Show("ลบรายการ สำเร็จ!");
            //}
              

           

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
           // radGridView1.ReadOnly = true;
            //btnView.Enabled = false;
            ////btnEdit.Enabled = true;
            //radGridView1.AllowAddNewRow = false;
            DataLoad();
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
            //if (MessageBox.Show("ต้องการบันทึก ?", "บันทึก", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    AddUnit();
            //    DataLoad();
            //}
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
                if (e.ColumnIndex == radGridView1.Columns["LotNo"].Index)
                {
                    string LotNo = radGridView1.Rows[e.RowIndex].Cells["LotNo"].Value.ToString();
                    string PONo = radGridView1.Rows[e.RowIndex].Cells["PORDER"].Value.ToString();
                    DateTime date1 = Convert.ToDateTime(radGridView1.Rows[e.RowIndex].Cells["DeliveryDate"].Value.ToString());
                    using (DataClasses1DataContext db = new DataClasses1DataContext())
                    {
                        tb_HistoryPrintSupplier tp = db.tb_HistoryPrintSuppliers.Where(t => t.PONo == PONo).FirstOrDefault();
                        if (tp != null)
                        {
                            tp.LotNo = LotNo;
                            db.SubmitChanges();
                        }
                        else
                        {
                            tb_HistoryPrintSupplier tn = new tb_HistoryPrintSupplier();
                            tn.PONo = PONo;
                            tn.LotNo = LotNo;
                            tn.PrintTAG = false;
                            tn.DeliveryDate = date1;
                            db.tb_HistoryPrintSuppliers.InsertOnSubmit(tn);
                            db.SubmitChanges();

                        }
                    }
                }
        

            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
            
                //DeleteUnit();
                //DataLoad();
            
        }

        int row = -1;
        private void radGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //dbClss.ExportGridCSV(radGridView1);
           dbClss.ExportGridXlSX(radGridView1);
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
            radGridView1.EnableFiltering = true;
        }

        private void btnUnfilter1_Click(object sender, EventArgs e)
        {
            radGridView1.EnableFiltering = false;
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //Example01.pdf
         //   System.Diagnostics.Process.Start(Environment.CurrentDirectory+@"\Example\Example01.pdf");

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void chkSelect_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            //if(chkSelect.Checked)
            //{
            //    foreach(GridViewRowInfo rd in radGridView1.Rows)
            //    {
            //        rd.Cells["chk"].Value = true;
            //    }

            //}else
            //{
            //    foreach (GridViewRowInfo rd in radGridView1.Rows)
            //    {
            //        rd.Cells["chk"].Value = false;
            //    }
            //}
        }

        private void btnSave_Click_2(object sender, EventArgs e)
        {
            //if (row >= 0)
            //{
                UploadMapping um = new UploadMapping();
                um.Show();
            //}
           

        }
        private void PrintTAG()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Supplier_TAG.rpt
                //@UserID
                //@Datex
                //WP=> SupplierTAG
                int chkAdd = 0;
                int Qty = 0;
                int Snp = 0;
                int TAG = 0;
                int Remain = 0;
                DateTime dl = DateTime.Now;
                string QrCode = "";
                string OfTAG = "";
                
                double ap = 0;
                int a = 0;
                //   DateTime DateDl = DateTime.Now;
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var td = db.TempPrintSuppliers.Where(t => t.UserID.ToLower() == dbClss.UserID.ToLower());
                    db.TempPrintSuppliers.DeleteAllOnSubmit(td);
                    db.SubmitChanges();
                    radGridView1.EndUpdate();
                    radGridView1.EndEdit();

                    foreach (GridViewRowInfo rd in radGridView1.Rows.Where(o => Convert.ToBoolean(o.Cells["chk"].Value)))
                    {
                        if (Convert.ToBoolean(rd.Cells["chk"].Value))
                        {
                            Snp = Convert.ToInt32(rd.Cells["LotSize"].Value);
                            Qty = Convert.ToInt32(rd.Cells["OrderQty"].Value);
                            dl = Convert.ToDateTime(rd.Cells["DeliveryDate"].Value);
                            if (Qty != 0 && Snp != 0)
                            {
                                a = 0;
                                ap = (Qty % Snp);
                                if (ap > 0)
                                    a = 1;
                                TAG = Convert.ToInt32(Math.Floor((Convert.ToDouble(Qty) / Convert.ToDouble(Snp)) + a));//.ToString("###");

                                //txtOftag.Text = Math.Ceiling((double)1.7 / 10).ToString("###");

                                Remain = Qty;
                            }
                            ////////////////////////////////////////////////
                            for (int i = 1; i <= TAG; i++)
                            {
                                if (Remain > Snp)
                                {
                                    Qty = Snp;
                                    Remain = Remain - Snp;
                                }
                                else
                                {
                                    Qty = Remain;
                                    Remain = 0;
                                }
                                OfTAG = i + "of" + TAG;
                                QrCode = "";
                                QrCode = "EX," + rd.Cells["PORDER"].Value.ToString() + "," + Qty + "," + Snp + "," + rd.Cells["LotNo"].Value.ToString() + "," + OfTAG + "," + rd.Cells["Code"].Value.ToString();
                                //MessageBox.Show(QrCode);
                                byte[] barcode = dbClss.SaveQRCode2D(QrCode);
                                
                                TempPrintSupplier ts = new TempPrintSupplier();
                                ts.UserID = dbClss.UserID;
                                ts.PONo = rd.Cells["PORDER"].Value.ToString();
                                ts.LotNo = rd.Cells["LotNo"].Value.ToString();
                                ts.TAGRemark = dl.ToString("dd/MM/yyyy");
                                ts.QRCode = barcode;
                                ts.PartName = rd.Cells["NAME"].Value.ToString();
                                ts.ItemNo = rd.Cells["Code"].Value.ToString();
                                ts.SNP = Convert.ToInt32(rd.Cells["LotSize"].Value);
                                ts.Company = rd.Cells["VendorName"].Value.ToString();
                                ts.Quantity = Qty;
                                ts.OfTAG = i + " / " + TAG;
                                ///////////////////////////////////////////////
                                db.TempPrintSuppliers.InsertOnSubmit(ts);
                                db.SubmitChanges();
                            }

                            tb_HistoryPrintSupplier tp = db.tb_HistoryPrintSuppliers.Where(t => t.PONo == rd.Cells["PORDER"].Value.ToString()).FirstOrDefault();
                            if (tp != null)
                            {
                                tp.LotNo = rd.Cells["LotNo"].Value.ToString();
                                tp.PrintTAG = true;
                                db.SubmitChanges();
                            }
                            else
                            {
                                tb_HistoryPrintSupplier tn = new tb_HistoryPrintSupplier();
                                tn.PONo = rd.Cells["PORDER"].Value.ToString();
                                tn.LotNo = rd.Cells["LotNo"].Value.ToString();
                                tn.PrintTAG = true;
                                tn.DeliveryDate = dl;
                                db.tb_HistoryPrintSuppliers.InsertOnSubmit(tn);
                                db.SubmitChanges();

                            }

                            chkAdd += 1;
                        }
                    }
                }

                Report.Reportx1.WReport = "SupplierTAG";
                Report.Reportx1.Value = new string[1];
                Report.Reportx1.Value[0] = dbClss.UserID;
                Report.Reportx1 op = new Report.Reportx1("Supplier_TAG.rpt");
                op.Show();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.Cursor = Cursors.Default;
        }

        private void txtItemNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                DataLoad();
            }
        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
            if (row >= 0)
            {
                string Code = radGridView1.Rows[row].Cells["Code"].Value.ToString();
                //delete
                if (MessageBox.Show("คุณต้องการลบ [ "+ Code  + " ] หรือไม่ ?", "ลบรายการ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    using (DataClasses1DataContext db = new DataClasses1DataContext())
                    {
                        tb_MapItemTPIC tb = db.tb_MapItemTPICs.Where(m => m.Code == Code).FirstOrDefault();
                        if (tb != null)
                        {

                            db.tb_MapItemTPICs.DeleteOnSubmit(tb);
                            db.SubmitChanges();
                            MessageBox.Show("ลบเรียบร้อยแล้ว!");
                            DataLoad();
                        }
                    }
                }
            }
        }
    }
}
