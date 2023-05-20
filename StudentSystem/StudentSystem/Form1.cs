using StudentSystem.DS;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;



namespace StudentSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DS.User_DS.USP_USER_SELECTDataTable UserDT = new User_DS.USP_USER_SELECTDataTable();
        DS.User_DSTableAdapters.USP_USER_SELECTTableAdapter UserAdapter = new DS.User_DSTableAdapters.USP_USER_SELECTTableAdapter();

        DS.Student_DS.USP_COURSE_SELECTDataTable StuDT = new Student_DS.USP_COURSE_SELECTDataTable();
        DS.Student_DSTableAdapters.USP_STUDENT_SELECTTableAdapter StuAdapt = new DS.Student_DSTableAdapters.USP_STUDENT_SELECTTableAdapter();

        DS.Student_DS.USP_COURSE_SELECTDataTable CourseDT = new Student_DS.USP_COURSE_SELECTDataTable();
        DS.Student_DSTableAdapters.USP_COURSE_SELECTTableAdapter CourseAdapter = new DS.Student_DSTableAdapters.USP_COURSE_SELECTTableAdapter();

        DS.Student_DS.USP_STUDENT_SEARCHDataTable SearchDT = new Student_DS.USP_STUDENT_SEARCHDataTable();
        DS.Student_DSTableAdapters.USP_STUDENT_SEARCHTableAdapter SearchAdapter = new DS.Student_DSTableAdapters.USP_STUDENT_SEARCHTableAdapter();

        DS.Student_DS.USP_STUDENT_SELECT_BYIDDataTable IDDT = new Student_DS.USP_STUDENT_SELECT_BYIDDataTable();
        DS.Student_DSTableAdapters.USP_STUDENT_SELECT_BYIDTableAdapter IDAdapter = new DS.Student_DSTableAdapters.USP_STUDENT_SELECT_BYIDTableAdapter();

        DS.Student_DS.USP_TEACHER_SELECTDataTable TeaDT = new Student_DS.USP_TEACHER_SELECTDataTable();
        DS.Student_DSTableAdapters.USP_TEACHER_SELECTTableAdapter TeaAdapter = new DS.Student_DSTableAdapters.USP_TEACHER_SELECTTableAdapter();

        public int userid;
       public string uname;
        private void gplogin_Enter(object sender, EventArgs e)
        {

        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            int blank = 0;
            if (txtname.Text == "")
            {
                lblnamee.Visible = true;
                blank = 1;
            }
            else { lblnamee.Visible = false; }
            if (txtsurname.Text == "")
            {
                lblsurnamee.Visible = true;
                blank = 1;
            }
            else {
                lblsurnamee.Visible = false;
            }
            if (txtemail.Text == "")
            {
                lblemaile.Visible = true;
                blank = 1;
            }
            else 
            {
                lblemaile.Visible = false;
            }

            if (txtemail.Text.Contains("@") && txtemail.Text.Contains("."))
            {
                lblemaile.Visible = false;
            }
            else
            {
                lblemaile.Visible = true;
                blank = 1;
            }
            if (txtcontact.Text == "")
            {
                lblmoe.Visible = true;
                blank = 1;
            }
            else
            {
                lblmoe.Visible = false;
            }

            if (blank == 0)
            {
                lblmoe.Visible = false;
                lblemaile.Visible = false;
                lblnamee.Visible = false;
                lblsurnamee.Visible = false;
//gpcourse.Visible = true;
                Drpyear.SelectedItem = 0;
                gpcourse.Enabled = true;
                CourseDT = CourseAdapter.SelectCourse();
                cmbcourse.DataSource = CourseDT;
                cmbcourse.DisplayMember = "CourseName";
                cmbcourse.ValueMember = "Coursefees";
                cmbcourse.Text = "SELECT";

                TeaDT = TeaAdapter.select();
                cmbteacher.DataSource = TeaDT;
                cmbteacher.DisplayMember = "TeacherName";
                cmbteacher.ValueMember = "ID";
                cmbteacher.Text = "SELECT";

                txtfees.Text = "";
            }
        }
        catch (Exception a)
        {
            MessageBox.Show(a.Message.ToString(), "Error!!");
        }
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_DS.USERSELECT' table. You can move, or remove it, as needed.
           // this.uSERSELECTTableAdapter.Select(this.user_DS.USERSELECT);
            // TODO: This line of code loads data into the 'student_DS.TEACHERSELECT' table. You can move, or remove it, as needed.
            //this.tEACHERSELECTTableAdapter.select();
            //DS.student_DSTEACHERSELECT.Select();
            // TODO: This line of code loads data into the 'student_DS.TEACHERSELECT' table. You can move, or remove it, as needed.
            //this.tEACHERSELECTTableAdapter.select(this.student_DS.TEACHERSELECT);
            //lbltime.Text = System.DateTime.Now.TimeOfDay.ToString(); ;
            lblsec.Text = System.DateTime.Now.ToString();
            label72.Text = System.DateTime.Now.DayOfWeek.ToString();
       }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try{
                
            if (txtusername.Text == "")
            {
                MessageBox.Show("Please, Enter UserName !!","Shubham");
            
            }
            else if (txtpassword.Text == "")
            {
                MessageBox.Show("Please, Enter Password !!","1234 ");

            }
            else
            {
                int user = 0;
                UserDT = UserAdapter.Select();
                for (int i = 0; i < UserDT.Rows.Count; i++)
                {
                  //  byte[] bb = Convert.FromBase64String(UserDT.Rows[i]["Password"].ToString());
                   // string getpass = System.Text.ASCIIEncoding.ASCII.GetString(bb);


                    if (txtusername.Text == UserDT.Rows[i]["UserName"].ToString() && txtpassword.Text == UserDT.Rows[i]["Password"].ToString())
                    {

                        userid =Convert.ToInt32(UserDT.Rows[i]["ID"].ToString());
                         uname = UserDT.Rows[i]["UserName"].ToString();
                        user = 1;
                    }
                }

                if (user == 0)
                {
                    MessageBox.Show("Invalid Username or Password !!");
                }
                else
                {
                    MessageBox.Show("Welcome to Student Management System.");
                    lbldisplay.Text = "Welcome " + uname;
                    lbldisplay.Visible = true;
                    txtusername.Text = "";
                    txtpassword.Text = "";
                    gplogin.Visible = false;
                    btnlogout.Visible = true;
                    pnllogo.Visible = true;
                }

            }
        }
        catch (Exception a)
        {
            MessageBox.Show(a.Message.ToString(), "Error!!");
        }
        }

        
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
            tbstudent.Visible = true;
            tbstudent.SelectedIndex = 0;
            studentclear();
            //CourseDT = CourseAdapter.SelectCourse();
            //cmbcourse.DataSource = CourseDT;
            //cmbcourse.DisplayMember = "CourseName";
            //cmbcourse.ValueMember = "Coursefees";
            //cmbcourse.Text = "SELECT";
            //groupBox2.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            tbstudent.Visible = true;
            btnedit.Visible = false;
            lblfees.Text = "";
            tbstudent.SelectedIndex = 2;
             lblfeeerror.Text ="";
             gpupdatefees.Visible = false;
             txtfeeid.Text = "";
             txtfeeadd.Text = "";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                dgstudent.DataSource = null;
                dgfess.DataSource = null;
                dgfess.Visible = false;
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 1;
                CourseDT = CourseAdapter.SelectCourse();
                cmbscoure.DataSource = CourseDT;
                cmbscoure.DisplayMember = "CourseName";
                cmbscoure.ValueMember = "Coursefees";
                cmbscoure.Text = "SELECT";

                TeaDT = TeaAdapter.select();
                cmmtach.DataSource = TeaDT;
                cmmtach.DisplayMember = "TeacherName";
                cmmtach.ValueMember = "ID";
                cmmtach.Text = "SELECT";

                txtsname.Text = "";
                lblrecord.Text = "";
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!");
            }
        
        }



        private void pictureBox6_Click(object sender, EventArgs e)
        {

            lblcourse.Text = ""; 
            tbstudent.Visible = true;
            tbstudent.SelectedIndex = 3;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 4;
                CourseDT = CourseAdapter.SelectCourse();
                dgcourse.DataSource = CourseDT;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!");
            }
        }

      

        private void btnlogout_Click(object sender, EventArgs e)
        {
            lbldisplay.Visible = false;
            lbldisplay.Text = "";
            gplogin.Visible = true;
            tbstudent.Visible = false;
            pnllogo.Visible = false;
            btnlogout.Visible = false;
        }

      

        private void btnfeeview_Click(object sender, EventArgs e)
        {
            try
            {
                txtfeepaid.ReadOnly = true;
                btnedit.Visible = false;
                txtfeename.ReadOnly = true;
                txtfeesure.ReadOnly= true;
                txtfeemobile.ReadOnly = true;
                txtfeemail.ReadOnly = true;
                lblfees.Text = "";
                if (txtfeeid.Text != "")
                {
                    IDDT = IDAdapter.SelectByID(Convert.ToInt32(txtfeeid.Text));
                    if (IDDT.Rows.Count > 0)
                    {
                        MessageBox.Show("Student Name is " + IDDT.Rows[0]["Studentname"].ToString() + " " + IDDT.Rows[0]["surename"].ToString());
                    
                        txtfeename.Text = IDDT.Rows[0]["Studentname"].ToString();
                        txtfeesure.Text = IDDT.Rows[0]["surename"].ToString();
                        txtfeemobile.Text = IDDT.Rows[0]["contactno"].ToString();
                        txtfeemail.Text = IDDT.Rows[0]["email"].ToString();
                        txtfeefees.Text = IDDT.Rows[0]["fees"].ToString();
                        txtfeepaid.Text = IDDT.Rows[0]["feespaid"].ToString();
                        txtfeerem.Text = IDDT.Rows[0]["feesrem"].ToString();
                        cmbfeecollege.Text = IDDT.Rows[0]["college"].ToString();
                        cmbfeecourse.Text = IDDT.Rows[0]["course"].ToString();
                        gpupdatefees.Visible = true;
                        lblfeeerror.Text = "";
                        btnedit.Visible = true;
                    }
                    else {

                        MessageBox.Show("Wrong Student ID");
                        lblfeeerror.Text = "";
                        gpupdatefees.Visible = false;
                        txtfeeid.Text = "";
                        txtfeeadd.Text = "";
                    }



                }
                else
                {
                    lblfeeerror.Text = "Please, Enter Student ID. !!";
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!");
            }
        }

        private void btnfeeupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfeeadd.Text != "")
                {


                    IDDT = IDAdapter.SelectByID(Convert.ToInt32(txtfeeid.Text));
                    //int feepaid = Convert.ToInt32(IDDT.Rows[0]["feespaid"].ToString()) + Convert.ToInt32(txtfeeadd.Text);
                    int feepaid = Convert.ToInt32(txtfeepaid.Text) + Convert.ToInt32(txtfeeadd.Text);

                    if (feepaid > Convert.ToInt32(txtfeefees.Text))
                    {
                        MessageBox.Show("Error !!, Pais Fees is never more then Total Course Fees");
                    }
                    else
                    {
                        int feerem = Convert.ToInt32(IDDT.Rows[0]["fees"].ToString()) - feepaid;
                        int update = StuAdapt.Update(Convert.ToInt32(txtfeeid.Text), txtfeename.Text, txtfeesure.Text, txtfeemobile.Text, txtfeemail.Text, txtfeefees.Text, feepaid.ToString(), feerem.ToString(), cmbfeecollege.Text, cmbfeecourse.Text);

                        if (update == 1)
                        {
                            //lblfees.Text = "Fees Updated Successfully.!!";
                            MessageBox.Show("Fees Updatd Successfully.!!");
                            txtfeepaid.ReadOnly = true;
                            txtfeeadd.Text = "";
                            txtfeename.Text = "";
                            txtfeesure.Text = "";
                            txtfeemobile.Text = "";
                            txtfeemail.Text = "";
                            txtfeefees.Text = "";
                            txtfeepaid.Text = "";
                            txtfeerem.Text = "";
                            cmbfeecollege.Text = "SELECT";

                            cmbfeecourse.Text = "SELECT";
                            gpupdatefees.Visible = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please, Insert Fees");
                
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!");
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            txtfeename.ReadOnly = false;
            txtfeemail.ReadOnly=false;
            txtfeesure.ReadOnly = false;
            txtfeepaid.ReadOnly = false;
            //txtfeefees.ReadOnly = false;
            //txtfeerem.ReadOnly = false;
            //txtfeepaid.ReadOnly = false;
            txtfeemobile.ReadOnly = false;
           // cmbfeecollege.Enabled = true;
           // cmbfeecourse.Enabled = true;
        }

        public void studentclear()
        {
            try
            {
                txtname.Text = "";
                txtsurname.Text = "";
                txtaddress.Text = "";
                txtpin.Text = "";
                txtcontact.Text = "";
                gpcourse.Enabled = false;
                txtemail.Text = "";
                //cmbcourse.SelectedIndex = 0;
                cmbcollege.SelectedIndex = 0;
                txtfees.Text = "";
                txtcontact.Text = "";
                //cmbteacher.SelectedIndex = 0;
               // gpcourse.Visible = false;
                lblstudentmsg.Text = "";
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfees.Text == "")
                {
                    MessageBox.Show("Please, Check your Course Fees.");
                }
                else
                {
                    int ins = StuAdapt.Insert(txtname.Text, txtsurname.Text, txtaddress.Text, txtpin.Text, txtcontact.Text, txtemail.Text, cmbcollege.Text, cmbcourse.Text, txtfees.Text, "0", txtfees.Text, cmbteacher.Text,txtproject.Text ,Drpyear.Text, datestart.Value.Date, dateend.Value.Date);

                    if (ins == 1)
                    {
                        studentclear();
                        lblstudentmsg.Text = "Student Added Successfully !!";
                        MessageBox.Show("Student Added Successfully !!");
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!! ");
            }
        }

        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbcourse.Text == "SELECT")
                {
                    txtfees.Text = "";
                }
                else
                {
                    txtfees.Text = cmbcourse.SelectedValue.ToString();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblrecord.Text = "";
                dgstudent.DataSource = null;
                dgstudent.Visible = true;
                dgfess.DataSource = null;
                dgfess.Visible = false;
                if (cmbscoure.Text == "SELECT")
                {
                    cmbscoure.Text = "";
                }
                if (cmbsfees.Text == "SELECT")
                {
                    cmbsfees.Text = "";
                }

                if (cmmtach.Text == "SELECT")
                {

                    SearchDT = SearchAdapter.select(txtsname.Text + '%', cmbscoure.Text, cmbsfees.Text,cmbyear.Text);
                    dgstudent.DataSource = SearchDT;
                }
                else
                {

                    DS.Student_DS.USP_STUDENT_SEARCH_BY_TEACHERDataTable TDT = new Student_DS.USP_STUDENT_SEARCH_BY_TEACHERDataTable();
                    DS.Student_DSTableAdapters.USP_STUDENT_SEARCH_BY_TEACHERTableAdapter TAdapter = new DS.Student_DSTableAdapters.USP_STUDENT_SEARCH_BY_TEACHERTableAdapter();
                    TDT = TAdapter.select(txtsname.Text + '%', cmbscoure.Text, cmbsfees.Text, cmmtach.Text, cmbyear.Text);
                    dgstudent.DataSource = TDT;
                }

                lblrecord.Text = "Record = " + dgstudent.RowCount.ToString();

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtsname.Text = "";
            cmbscoure.Text = "SELECT";
            cmbsfees.Text = "SELECT";
            cmmtach.Text = "SELECT";
            dgstudent.DataSource = null;
            dgfess.DataSource = null;
            lblrecord.Text = "";
        }

        private void btnaddcourse_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcoursename.Text == "")
                {
                    lblcnamee.Visible = true;
                    lblcourse.Text = "";

                }
                else if (txtcoursefees.Text == "")
                {
                    lblcpricee.Visible = true;
                    lblcourse.Text = "";
                }
                else if (cmbduration.Text == "SELECT")
                {
                    lblduration.Visible = true;
                    lblcourse.Text = "";
                }
                else
                {
                    lblcnamee.Visible = false;
                    lblcpricee.Visible = false;
                    lblduration.Visible = false;
                    lblcourse.Text = "";
                    int ins = CourseAdapter.Insert(txtcoursename.Text, txtcoursefees.Text, cmbduration.Text);
                    if (ins == 1)
                    {
                        lblcourse.Text = "Course Added Successfully.";
                        MessageBox.Show("Course Added Successfully. !!");
                        txtcoursename.Text = "";
                        txtcoursefees.Text = "";
                        cmbduration.Text = "SELECT";
                    }

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!");
            }
            
        }

        private void tbstudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbstudent.SelectedIndex == 0)
                {
                    tbstudent.Visible = true;
                    //tbstudent.SelectedIndex = 0;
                    studentclear();
                    CourseDT = CourseAdapter.SelectCourse();
                    cmbcourse.DataSource = CourseDT;
                    cmbcourse.DisplayMember = "CourseName";
                    cmbcourse.ValueMember = "Coursefees";
                    cmbcourse.SelectedIndex = 0;
                }
                else if (tbstudent.SelectedIndex == 1)
                {
                    tbstudent.Visible = true;
                    dgstudent.DataSource = null;
                    dgfess.DataSource = null;
                    dgfess.Visible = false;
                    //tbstudent.SelectedIndex = 1;
                    CourseDT = CourseAdapter.SelectCourse();
                    cmbscoure.DataSource = CourseDT;
                    cmbscoure.DisplayMember = "CourseName";
                    cmbscoure.ValueMember = "Coursefees";
                    cmbscoure.Text = "SELECT";


                    TeaDT = TeaAdapter.select();
                    cmmtach.DataSource = TeaDT;
                    cmmtach.DisplayMember = "TeacherName";
                    cmmtach.ValueMember = "ID";
                    cmmtach.Text = "SELECT";
                    txtsname.Text = "";
                    lblrecord.Text = "";
                }
                else if (tbstudent.SelectedIndex == 2)
                {
                    tbstudent.Visible = true;
                    lblfees.Text = "";
                    //tbstudent.SelectedIndex = 2;
                    lblfeeerror.Text = "";
                    gpupdatefees.Visible = false;
                    txtfeeid.Text = "";
                    txtfeeadd.Text = "";
                    btnedit.Visible = false;
  
                }
                else if (tbstudent.SelectedIndex == 3)
                {
                    lblcourse.Text = "";
                    tbstudent.Visible = true;
                    // tbstudent.SelectedIndex = 3;
                }
                else if (tbstudent.SelectedIndex == 4)
                {
                    tbstudent.Visible = true;
                    // tbstudent.SelectedIndex = 4;
                    CourseDT = CourseAdapter.SelectCourse();
                    dgcourse.DataSource = CourseDT;

                }
                else if (tbstudent.SelectedIndex == 5)
                {

                }
                else if (tbstudent.SelectedIndex == 6)
                {
                    dgteacher.DataSource = null;
                    TeaDT = TeaAdapter.select();
                    dgteacher.DataSource = TeaDT;
                }
                else if (tbstudent.SelectedIndex == 7)
                {
                    lblerror.Text = "";

                    if (userid == 1 || userid == 2)
                    {
                        tbadmin.Visible = true;
                        lblerror.Visible = false;
                        lblerror.Text = "";
                        txtsid.Text = "";
                        dgstu.Visible = false;
                        dgstu.DataSource = null;
                        btndel.Visible = false;

                    }
                    else
                    {
                        tbadmin.Visible = false;
                        lblerror.Visible = true;
                        lblerror.Text = "Sorry !!, You are unable to get this faclity !!";

                    }
                    
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!");
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open Image Files";
            //fDialog.Filter = "JPEG Files|*.jpeg|GIF Files|*.gif";
            fDialog.InitialDirectory = @"C:\";
            
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(fDialog.FileName.ToString());
                //richTextBox1.SaveFile(fDialog.FileName,RichTextBoxStreamType.
               // txtimg.Text = fDialog.FileName;
               
            }
        }

        private void btnteacher_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtteacher.Text == "")
                {
                    MessageBox.Show("Please, Entet Teacher Name");
                }
                else
                {

                    int ins = TeaAdapter.Insert(txtteacher.Text, txtquli.Text, txtsubject.Text);

                    if (ins == 1)
                    {
                        MessageBox.Show("Teacher Added Successfully");
                        txtteacher.Text = "";
                        txtsubject.Text = "";
                        txtquli.Text = "";
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tbstudent.Visible = true;
            tbstudent.SelectedIndex = 5;
            txtteacher.Text = "";
            txtsubject.Text = "";
            txtquli.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                dgteacher.DataSource = null;
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 6;

                TeaDT = TeaAdapter.select();
                dgteacher.DataSource = TeaDT;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!! ");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            lblsec.Text = System.DateTime.Now.ToString();
          

        }

       

        private void btnseachfees_Click(object sender, EventArgs e)
        {
            try
            {
                lblrecord.Text = "";
                dgstudent.DataSource = null;
                dgstudent.Visible = false;
                dgfess.DataSource = null;
                dgfess.Visible = true;
                if (cmbscoure.Text == "SELECT")
                {
                    cmbscoure.Text = "";
                }
                if (cmbsfees.Text == "SELECT")
                {
                    cmbsfees.Text = "";
                }

                if (cmmtach.Text == "SELECT")
                {
                    DS.Student_DS.USP_STUDENT_SEARCH_BY_FEESDataTable FDT = new Student_DS.USP_STUDENT_SEARCH_BY_FEESDataTable();
                    DS.Student_DSTableAdapters.USP_STUDENT_SEARCH_BY_FEESTableAdapter FAdapter = new  DS.Student_DSTableAdapters.USP_STUDENT_SEARCH_BY_FEESTableAdapter();

                    FDT = FAdapter.selectfees(txtsname.Text + '%', cmbscoure.Text, cmbsfees.Text, cmbyear.Text);
                    dgfess.DataSource = FDT;
                    double fees=0,rfees=0,pfees = 0;
                    for (int i = 0; i < FDT.Rows.Count; i++)
                    {

                        pfees = Convert.ToDouble(FDT.Rows[i]["feespaid"].ToString()) + pfees;
                        fees = Convert.ToDouble(FDT.Rows[i]["fees"].ToString()) + fees;
                        rfees = Convert.ToDouble(FDT.Rows[i]["feesrem"].ToString()) + rfees;
                    }

                    lblresult.Text = pfees.ToString();
                    lblfeesremmm.Text = rfees.ToString();
                    lblfeesssss.Text = fees.ToString();
                }
                else
                {

                    DS.Student_DS.USP_STUDENT_SEARCH_BY_FEESDataTable TDT = new Student_DS.USP_STUDENT_SEARCH_BY_FEESDataTable();
                    DS.Student_DSTableAdapters.USP_STUDENT_SEARCH_BY_FEESTableAdapter TAdapter = new DS.Student_DSTableAdapters.USP_STUDENT_SEARCH_BY_FEESTableAdapter();
                    TDT = TAdapter.selectfeesTeacher(txtsname.Text + '%', cmbscoure.Text, cmbsfees.Text, cmmtach.Text, cmbyear.Text);
                    dgfess.DataSource = TDT;

                    double fees = 0, rfees = 0, pfees = 0;
                    for (int i = 0; i < TDT.Rows.Count; i++)
                    {

                        pfees = Convert.ToDouble(TDT.Rows[i]["feespaid"].ToString()) + pfees;
                        fees = Convert.ToDouble(TDT.Rows[i]["fees"].ToString()) + fees;
                        rfees = Convert.ToDouble(TDT.Rows[i]["feesrem"].ToString()) + rfees;
                    }


                    lblresult.Text = pfees.ToString();
                    lblfeesremmm.Text = rfees.ToString();
                    lblfeesssss.Text = fees.ToString();
                }

                lblrecord.Text = "Record = " + dgfess.RowCount.ToString();

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void txtfeepaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int fee = Convert.ToInt32(txtfeefees.Text) - Convert.ToInt32(txtfeepaid.Text);
                txtfeerem.Text = Convert.ToString(fee);
            }
            catch(Exception)
            { 
           
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtauser.Text == "")
                {
                    MessageBox.Show("UserName cant't be blank!!");
                }
                else if (txtapass.Text == "")
                {
                    MessageBox.Show("Password can't be blank !!");
                }
                else
                {

                   // byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(txtapass.Text);
                  //  string encryptedConnectionString = Convert.ToBase64String(b);
                  
                   // byte[] bb = Convert.FromBase64String(encryptedConnectionString);
                  //  string decryptedConnectionString = System.Text.ASCIIEncoding.ASCII.GetString(bb);


                    int m = UserAdapter.Insert(txtauser.Text, txtapass.Text);

                    if (m == 1)
                    {

                        MessageBox.Show("User Added Successfully. !!");
                        txtauser.Text = "";
                        UserDT = UserAdapter.Select();
                        cmbuser.DataSource = UserDT;
                        cmbuser.DisplayMember = "UserName";
                        cmbuser.ValueMember = "ID";
                        txtapass.Text = "";
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            lblpass.Visible = false;
            btnnewpass.Visible = false;
            txtchangepassword.Visible = false;
            try
            {
                if (Convert.ToInt16(cmbuser.SelectedValue) == 1 || Convert.ToInt16(cmbuser.SelectedValue) == 2)
                {
                    MessageBox.Show("You can't Delete this User. !!");
                }
                else
                {
                    int a = UserAdapter.Delete(Convert.ToInt16(cmbuser.SelectedValue));

                    if (a == 1)
                    {
                        MessageBox.Show("User Deleted Successfully. !!");
                        UserDT = UserAdapter.Select();
                        cmbuser.DataSource = UserDT;
                        cmbuser.DisplayMember = "UserName";
                        cmbuser.ValueMember = "ID";
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }

        }

        private void tbadmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (tbadmin.SelectedIndex == 0)
                {
                    dgstu.Visible = false;
                    btndel.Visible = false;
                    txtsid.Text = "";
                   
                    dgstu.DataSource = null;
                   
                }
                else if (tbadmin.SelectedIndex == 1)
                {
                    gpteacher.Visible = false;
                    txtateacherid.Text = "";
                    txtateachname.Text = "";
                    txtaqulif.Text = "";
                    txtasubject.Text = "";
                }
                else if (tbadmin.SelectedIndex == 2)
                {
                    gpupdatecourse.Visible = false;
                    txtcid.Text = "";
                    txtcname.Text = "";
                    txtcfees.Text = "";
                    cmbcduration.SelectedIndex = 0;

                }
                else if (tbadmin.SelectedIndex == 3)
                {
                    txtauser.Text = "";
                    txtapass.Text = "";
                    UserDT = UserAdapter.Select();
                    cmbuser.DataSource = UserDT;
                    cmbuser.DisplayMember = "UserName";
                    cmbuser.ValueMember = "ID";

                    lblpass.Visible = false;
                    btnnewpass.Visible = false;
                    txtchangepassword.Visible = false;

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtateacherid.Text == "")
                {
                    MessageBox.Show("Please Enter Teacher ID");

                }
                else
                {
                    TeaDT = TeaAdapter.SelectTeabyID(Convert.ToInt16(txtateacherid.Text));
                    if (TeaDT.Rows.Count > 0)
                    {
                        gpteacher.Visible = true;
                        txtateachname.Text = TeaDT.Rows[0]["TeacherName"].ToString();
                        txtasubject.Text = TeaDT.Rows[0]["Subject"].ToString();
                        txtaqulif.Text = TeaDT.Rows[0]["Qulification"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Teacher ID");
                        gpteacher.Visible = false;
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtateachname.Text == "")
                {
                    MessageBox.Show("Teacher Name can't be blank");

                }
                else if (txtasubject.Text == "")
                {
                    MessageBox.Show("Subject Can't be blank");
                }
                else if (txtaqulif.Text == "")
                {
                    MessageBox.Show("Qulification field can't be blank");
                }
                else
                {
                    int u = TeaAdapter.Update(Convert.ToInt32(txtateacherid.Text), txtateachname.Text, txtaqulif.Text, txtasubject.Text);
                    if (u == 1)
                    {
                        MessageBox.Show("Teacher Detail Updated Successfully. !!");
                        gpteacher.Visible = false;
                        txtateachname.Text = "";
                        txtaqulif.Text = "";
                        txtasubject.Text = "";
                        txtateacherid.Text = "";
                    }

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
               // xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;
                if (dgfess.Visible == true)
                {
                    for (i = 0; i <= dgfess.RowCount - 1; i++)
                    {
                        for (j = 0; j <= dgfess.ColumnCount - 1; j++)
                        {
                            DataGridViewCell cell = dgfess[j, i];
                            xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                        }
                    }
                    xlWorkBook.SaveAs("StudentFees.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    MessageBox.Show("Excel file created , you can find the file 'StudentFees.xls' in My Document");

                }
                else if (dgstudent.Visible == true)
                {
                    for (i = 0; i <= dgstudent.RowCount - 1; i++)
                    {
                        for (j = 0; j <= dgstudent.ColumnCount - 1; j++)
                        {
                            DataGridViewCell cell = dgstudent[j, i];
                            xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                        }
                    }

                    xlWorkBook.SaveAs("studentDetail.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    MessageBox.Show("Excel file created , you can find the file 'StudentDetail.xls' in My Document");

                }


                // releaseObject(xlWorkSheet);
                // releaseObject(xlWorkBook);
                //releaseObject(xlApp);

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }   
        

            
        }

        private void button15_Click(object sender, EventArgs e)
        {try{
            if (txtcid.Text == "")
            {
                MessageBox.Show("Please, Enter Course ID");
            }
            else
            {
                CourseDT = CourseAdapter.SelectCoursebyID(Convert.ToInt32(txtcid.Text));
                if (CourseDT.Rows.Count > 0)
                {
                    gpupdatecourse.Visible = true;
                    txtcname.Text = CourseDT.Rows[0]["Coursename"].ToString();
                    txtcfees.Text = CourseDT.Rows[0]["CourseFees"].ToString();
                   cmbcduration.SelectedItem= CourseDT.Rows[0]["Duration"].ToString();

                }
                else
                {
                    MessageBox.Show("Invalid Course ID");
                }
            }
        }
        catch (Exception a)
        {
            MessageBox.Show(a.Message.ToString(), "Error !!");
        }
        }

        private void button14_Click(object sender, EventArgs e)
        {try{
            if (txtcname.Text == "")
            {
                MessageBox.Show("Course Name can't be blank");

            }
            else if (txtcfees.Text == "")
            {
                MessageBox.Show("Course Fees Can't be blank");
            }
            else
            {
                int u = CourseAdapter.Update(Convert.ToInt32(txtcid.Text), txtcname.Text, txtcfees.Text, cmbcduration.SelectedItem.ToString());
                if (u == 1)
                {
                    MessageBox.Show("Course Detail Updated Successfully. !!");
                    gpupdatecourse.Visible = false;
                    txtcname.Text = "";
                    txtcfees.Text = "";
                    txtcid.Text = "";
                }

            }
        }
        catch (Exception a)
        {
            MessageBox.Show(a.Message.ToString(), "Error !!");
        }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try{
            if (txtsid.Text == "")
            {
                MessageBox.Show("Please, Enter Student ID");
            }
            else
            {
                IDDT = IDAdapter.SelectByID(Convert.ToInt32(txtsid.Text));
                if (IDDT.Rows.Count > 0)
                {
                    dgstu.DataSource = IDDT;
                    dgstu.Visible = true;
                    btndel.Visible = true;

                }
                else
                {
                    MessageBox.Show("Invalid User ID");
                    dgstu.Visible = false;
                    btndel.Visible = false;
                }
            }
        }
        catch (Exception a)
        {
            MessageBox.Show(a.Message.ToString(), "Error !!");
        }
        
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure !! you want to Delete this student","Student", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int DEL = StuAdapt.Delete(Convert.ToInt32(txtsid.Text));
                    if (DEL == 1)
                    {
                        MessageBox.Show("Student Deleted Successfully. !!");
                        dgstu.Visible = false;
                        dgstu.DataSource = null;
                        btndel.Visible = false;
                        txtsid.Text = "";
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            IDDT = IDAdapter.SelectByID(Convert.ToInt32(cmbuser.SelectedValue));
            lblpass.Visible = true;
            btnnewpass.Visible = true;
            txtchangepassword.Text = "";
            txtchangepassword.Visible = true;
        }

        private void btnnewpass_Click(object sender, EventArgs e)
        {
            if (txtchangepassword.Text == "")
            {
                MessageBox.Show("Please, Enter New Password");
            }
            else
            {
               // byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(txtchangepassword.Text);
                //string newpass = Convert.ToBase64String(b);

                int u = UserAdapter.Update(Convert.ToInt32(cmbuser.SelectedValue), txtchangepassword.Text);
                if (u == 1)
                {
                    MessageBox.Show("Password changed successfully. !!");
                    lblpass.Visible = false;
                    btnnewpass.Visible = false;
                    txtchangepassword.Text = "";
                    txtchangepassword.Visible = false;
                }
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    
    }
}