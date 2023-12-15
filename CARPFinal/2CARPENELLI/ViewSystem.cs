using RSCSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2CARPENELLI
{
    public partial class ViewSystem : Form
    {
        private Label memoryLoc_txt;
        private CPU cpu;
        private Memory memory;

        //Breakpoints
        private List<int> breakpoints;

        #region VisualizationOpcodes
        public const short opcodeNOP = 0x00;
        public const short opcodeLDAC = 0x01;
        public const short opcodeSTAC = 0x02;
        public const short opcodeMVAC = 0x03;
        public const short opcodeMOVR = 0x04;
        public const short opcodeJUMP = 0x05;
        public const short opcodeJMPZ = 0x06;
        public const short opcodeJPNZ = 0x07;
        public const short opcodeADD = 0x08;
        public const short opcodeSUB = 0x09;
        public const short opcodeINAC = 0x0a;
        public const short opcodeCLAC = 0x0b;
        public const short opcodeAND = 0x0c;
        public const short opcodeOR = 0x0d;
        public const short opcodeXOR = 0x0e;
        public const short opcodeNOT = 0x0f;
        public const short opcodeEND = 0xff;

        short[] memorycode;
        int fetchCounter = 0;
        int memoryCount = 0;

        int ldacCounter = 0;
        int stacCounter = 0;

        short instructadv1;
        short instructadv2;
        #endregion

        #region AnimationBooleans
        private bool CPUToA = false;
        private bool CPUToD = false;
        private bool AToM = false;
        private bool DToM = false;
        private bool AToP5 = false;
        private bool P5ToM = false;
        private bool AToCPU = false;
        private bool DToCPU = false;
        private bool E3ToA = false;
        private bool E4ToD = false;
        private bool LP7ToM = false;
        private bool SP5ToLP5 = false;
        private bool LP5ToDecoder = false;
        private bool LP8ToIO = false;
        private bool LP7ToLP8 = false;
        private bool DToLP7 = false;
        #endregion

        public ViewSystem(Label memoryLoc, CPU cpu, Memory memory, List<int> breakpoints)
        {
            InitializeComponent();

            #region Hidden Items
            //clkRed
            pictureBox44.Hide();
            pictureBox42.Hide();
            pictureBox43.Hide();
            pictureBox45.Hide();
            //-----

            //readRed
            pictureBox46.Hide();
            pictureBox47.Hide();
            pictureBox48.Hide();
            pictureBox49.Hide();
            pictureBox50.Hide();
            pictureBox51.Hide();
            pictureBox52.Hide();
            pictureBox53.Hide();
            //-----

            //writeRed           
            pictureBox55.Hide();
            pictureBox56.Hide();
            pictureBox57.Hide();
            //-----


            //-----------------------------
            //sprites/redDot
            move1.Hide();
            move2.Hide();
            move3.Hide();
            move4.Hide();
            move5.Hide();
            move6.Hide();
            move7.Hide();
            move8.Hide();
            move9.Hide();
            move10.Hide();
            move11.Hide();
            move12.Hide();
            //------------------------------
            #endregion
            this.memoryLoc_txt = memoryLoc;
            this.cpu = cpu;
            this.memory = memory;
            SetRegisters();
            this.breakpoints = breakpoints;
            cpu.SetViewSystem(this);
        }

        #region RegistersReset
        public void SetRegisters()
        {
            cpu.SetRegisters(ar_txt,pc_txt,dr_txt,tr_txt,ir_txt,r_txt,ac_txt,z_txt);
        }
        public void ResetRegisters()
        {
            ar_txt.Text = "0000 0000 0000 0000";
            pc_txt.Text = "0000 0000 0000 0000";
            dr_txt.Text = "0000 0000";
            tr_txt.Text = "0000 0000";
            ir_txt.Text = "0000 0000";
            r_txt.Text = "0000 0000";
            ac_txt.Text = "0000 0000";
            z_txt.Text = "0";
        }
        #endregion

        #region Animation Things
        int startposX;
        int startposY;

        
        private void Move_Animation(PictureBox start, PictureBox end, Timer timer, int axis, int direction, bool condition)
        {
            int anim_speed = 2;
            switch (axis)
            {
                case 0: // X axis
                    if (direction == 0) // right
                    {
                        if (start.Location.X >= end.Location.X)
                        {
                            start.Hide();
                            timer.Stop();
                            start.Location = new Point(startposX, start.Location.Y);
                        }
                        else
                        {
                            start.Location = new Point(start.Location.X + anim_speed, start.Location.Y);
                        }
                    }
                    else // left
                    {
                        if (start.Location.X <= end.Location.X)
                        {
                            start.Hide();
                            timer.Stop();
                            start.Location = new Point(startposX, start.Location.Y);
                        }
                        else
                        {
                            start.Location = new Point(start.Location.X - anim_speed, start.Location.Y);
                        }
                    }
                    break;
                case 1: // Y axis
                    if (direction == 0) // down
                    {
                        if (start.Location.Y >= end.Location.Y)
                        {
                            start.Hide();
                            timer.Stop();
                            start.Location = new Point(start.Location.X, startposY);
                        }
                        else
                        {
                            start.Location = new Point(start.Location.X, start.Location.Y + anim_speed);
                        }
                    }
                    else // up
                    {
                        if (start.Location.Y >= end.Location.Y)
                        {
                            start.Hide();
                            timer.Stop();
                            start.Location = new Point(start.Location.X, startposY);
                        }
                        else
                        {
                            start.Location = new Point(start.Location.X, start.Location.Y - anim_speed);
                        }
                    }
                    break;
            }
        }
        //---------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            Move_Animation(move1, endPoint1, timer1, 0, 0, CPUToA);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Move_Animation(move2, endPoint2, timer2, 0, 0, CPUToD);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Move_Animation(move3, endPoint3, timer3, 0, 0, AToM);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Move_Animation(move4, endPoint4, timer4, 0, 0, DToM);
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            Move_Animation(move3, startPoint5, timer5, 0, 0, AToP5);
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            Move_Animation(move5, endPoint3, timer6, 0, 0, P5ToM);
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            Move_Animation(move6, startPoint3, timer7, 0, 1, AToCPU);
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            Move_Animation(move7, startPoint1, timer8, 0, 1, DToCPU);
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            Move_Animation(move8, startPoint2, timer9, 0, 1, E3ToA);
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            Move_Animation(move9, startPoint4, timer10, 0, 1, E4ToD);
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            Move_Animation(move10, endPoint4, timer11, 0, 0, LP7ToM);
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            Move_Animation(move5, locPoint5, timer12, 1, 0, SP5ToLP5);
        }

        private void timer13_Tick(object sender, EventArgs e)
        {
            Move_Animation(move11, locPoint6, timer13, 0, 0, LP5ToDecoder);
        }

        private void timer14_Tick(object sender, EventArgs e)
        {
            Move_Animation(move12, locPoint10, timer14, 0, 0, LP8ToIO);
        }

        private void timer15_Tick(object sender, EventArgs e)
        {
            Move_Animation(move10, locPoint8, timer15, 1, 0, LP7ToLP8);
        }

        private void timer16_Tick(object sender, EventArgs e)
        {
            Move_Animation(move4, locPoint7, timer16, 0, 0, DToLP7);
        }
        //-----------------------------------------------------

        //test button
        private void TEST_Click(object sender, EventArgs e)
        {
            //all dot animations
            //CPUToARegister();
            //CPUToDRegister();
            //ARegisterToM();
            //DRegisterToM();
            //ARegisterToPoint5();
            //Point5ToM();
            //ARegisterToCPU();
            //DRegisterToCPU();
            //EndPoint3ToARegister();
            //EndPoint4ToDRegister();
            //LocPoint7ToM();
            //StartPoint5ToLocPoint5();
            // LocPoint5ToDecoder();
            // LocPoint8ToIO();
            // LocPoint7ToLocPoint8();
            // DRegisterToLocPoint7();
            //color animations
            /* clkRed();
             readRed();
             writeRed();*/
            //ALU and CU color animations
            /* ALURed();
             CURed();*/
            //All register color animations
            /*ARRed();
            PCRed();
            IRRed();
            DRRed();
            TRRed();
            RRed();
            ACRed();
            ZRed();*/
        }

        //functions to call for animation
        public void CPUToARegister()
        {
            startposX = move1.Location.X;
            timer1.Start();
            move1.Show();
            CPUToA = true;
        }
        public void CPUToDRegister()
        {
            startposX = move2.Location.X;
            timer2.Start();
            move2.Show();
            CPUToD = true;
        }

        public void ARegisterToM()
        {
            startposX = move3.Location.X;
            timer3.Start();
            move3.Show();
            AToM = true;
        }

        public void DRegisterToM()
        {
            startposX = move4.Location.X;
            timer4.Start();
            move4.Show();
            DToM = true;
        }

        public void ARegisterToPoint5()
        {
            startposX = move3.Location.X;
            timer5.Start();
            move3.Show();
            AToP5 = true;
        }

        public void Point5ToM()
        {
            startposX = move5.Location.X;
            timer6.Start();
            move5.Show();
            P5ToM = true;
        }

        public void ARegisterToCPU()
        {
            startposX = move7.Location.X;
            timer8.Start();
            move7.Show();
            AToCPU = true;
        }

        public void DRegisterToCPU()
        {
            startposX = move8.Location.X;
            timer9.Start();
            move8.Show();
            DToCPU = true;
        }

        public void EndPoint3ToARegister()
        {
            startposX = move6.Location.X;
            timer7.Start();
            move6.Show();
            E3ToA = true;
        }

        public void EndPoint4ToDRegister()
        {
            startposX = move9.Location.X;
            timer10.Start();
            move9.Show();
            E4ToD = true;
        }

        public void LocPoint7ToM()
        {
            startposX = move10.Location.X;
            timer11.Start();
            move10.Show();
            LP7ToM = true;
        }

        public void StartPoint5ToLocPoint5()
        {
            startposX = move5.Location.X;
            timer12.Start();
            move5.Show();
            SP5ToLP5 = true;
        }

        public void LocPoint5ToDecoder()
        {
            startposX = move11.Location.X;
            timer13.Start();
            move11.Show();
            LP5ToDecoder = true;
        }

        public void LocPoint8ToIO()
        {
            startposX = move12.Location.X;
            timer14.Start();
            move12.Show();
            LP8ToIO = true;
        }

        public void LocPoint7ToLocPoint8()
        {
            startposX = move10.Location.X;
            timer15.Start();
            move10.Show();
            LP7ToLP8 = true;
        }

        public void DRegisterToLocPoint7()
        {
            startposX = move4.Location.X;
            timer16.Start();
            move4.Show();
            DToLP7 = true;
        }
        //-------------------------
        //color animation
        public void clkRed()
        {
            pictureBox5.Hide();
            pictureBox11.Hide();
            pictureBox12.Hide();
            pictureBox42.Show();
            pictureBox43.Show();
            pictureBox45.Show();
            lblClock.ForeColor = Color.Red;
            lblClk.ForeColor = Color.Red;
            clockTimer.Start();
        }
        private void ClockTick(object sender, EventArgs e)
        {
            pictureBox5.Show();
            pictureBox11.Show();
            pictureBox12.Show();
            pictureBox44.Hide();
            pictureBox42.Hide();
            pictureBox43.Hide();
            pictureBox45.Hide();
            lblClock.ForeColor = Color.White;
            lblClk.ForeColor = Color.Black;
            clockTimer.Stop();
        }
        public void readRed(int num)
        {
            if(num > 0)
            {
                label29.ForeColor = Color.Red;
                lblRead.ForeColor = Color.Red;
                pictureBox27.Hide();
                pictureBox28.Hide();
                pictureBox29.Hide();
                pictureBox30.Hide();
                pictureBox31.Hide();
                pictureBox32.Hide();
                pictureBox46.Show();
                pictureBox47.Show();
                pictureBox48.Show();
                pictureBox49.Show();
                pictureBox50.Show();
                pictureBox51.Show();
                pictureBox52.Show();
                pictureBox53.Show();
            }
            else
            {
                label29.ForeColor = Color.White;
                lblRead.ForeColor = Color.White;
                pictureBox27.Show();
                pictureBox28.Show();
                pictureBox29.Show();
                pictureBox30.Show();
                pictureBox31.Show();
                pictureBox32.Show();
                pictureBox46.Hide();
                pictureBox47.Hide();
                pictureBox48.Hide();
                pictureBox49.Hide();
                pictureBox50.Hide();
                pictureBox51.Hide();
                pictureBox52.Hide();
                pictureBox53.Hide();
            }
        }

        public void writeRed()
        {
            lblWrite.ForeColor = Color.Red;
            pictureBox19.Hide();
            pictureBox20.Hide();
            pictureBox33.Hide();
            pictureBox34.Hide();
            pictureBox35.Hide();
            pictureBox36.Hide();
            pictureBox55.Show();
            pictureBox56.Show();
            pictureBox57.Show();
        }



        //ALU and CU Red
        public void ALURed()
        {
            lblALU.ForeColor = Color.Red;
        }

        public void CURed()
        {
            lblCU.ForeColor = Color.Red;
        }

        //-------------------------------
        //All 8 register to Red
        public void ARRed(int num)
        {
            if (num > 0)
                lblAR.ForeColor = Color.Red;
            else
                lblAR.ForeColor = Color.White;
        }

        public void PCRed(int num)
        {
            if (num > 0)
                lblPC.ForeColor = Color.Red;
            else
                lblPC.ForeColor = Color.White;

        }

        public void DRRed(int num)
        {   
            if(num>0)
                lblDR.ForeColor = Color.Red;
            else
                lblDR.ForeColor = Color.White;

        }
        public void TRRed(int num)
        {
            if (num > 0)
                lblTR.ForeColor = Color.Red;
            else
                lblTR.ForeColor = Color.White;

        }
        public void IRRed(int num)
        {
            if (num > 0)
                lblIR.ForeColor = Color.Red;
            else
                lblIR.ForeColor = Color.White;

        }
        public void RRed(int num)
        {
            if (num > 0)
                lblR.ForeColor = Color.Red;
            else
                lblR.ForeColor = Color.White;

        }
        public void ACRed(int num)
        {
            if (num > 0)
                lblAC.ForeColor = Color.Red;
            else
                lblAC.ForeColor = Color.White;
        }
        public void ZRed(int num)
        {
            if (num > 0)
                lblZ.ForeColor = Color.Red;
            else
                lblZ.ForeColor = Color.White;

        }
        #endregion

        #region Visualization Buttons
        private void FullCycle(object sender, EventArgs e)
        {
            ResetRegisters();
            cpu.ResetRegisters();
            fetchCounter = 0;
            memoryCount = 0;
            memorycode = memory.GetInstructions();
            fullCycleTimer.Start();
            if (memoryCount == memorycode.Length)
            {
                fullCycleTimer.Stop();
            }
        }
        private void Start_RSCPU(object sender, EventArgs e)
        {
            ResetRegisters();
            cpu.ResetRegisters();
            fetchCounter = 0;
            memoryCount = 0;
            memorycode = memory.GetInstructions();
            ExecuteMicrocode();
        }
        private void NextInstruction(object sender, EventArgs e)
        {
            ExecuteMicrocode();
        }
        private void Pause_RSCS(object sender, EventArgs e)
        {
            cpu.Status_txt.Text = "Paused";
            animationTimer.Stop();
            fullCycleTimer.Stop();
        }
        private void Continue_RSCS(object sender, EventArgs e)
        {
            cpu.Status_txt.Text = "Running";
            animationTimer.Start();
            fullCycleTimer.Start();
        }
        #endregion

        #region RSCPU Visualization
        public void ExecuteMicrocode()
        {
            animationTimer.Start();
            Console.WriteLine(memorycode[memoryCount]);
            if (fetchCounter < 3)
            {
                clkRed();
                cpu.Fetches(memorycode[memoryCount], fetchCounter);
                fetchCounter++;
            }
            else
            {
                InstructionFinder();
            }
        }
        public void InstructionFinder()
        {
            clkRed();
            instructadv1 = memorycode[memoryCount + 1];
            instructadv2 = memorycode[memoryCount + 2];
            int m1 = memoryCount + 1;
            int m2 = memoryCount + 2;
            Console.WriteLine(memorycode[memoryCount]);
            switch (memorycode[memoryCount])
            {
                case opcodeNOP:
                    memoryLoc_txt.Text = memoryCount.ToString();
                    Breakpoint(memoryCount);
                    // Perform actions for NOP instruction
                    memoryCount++;
                    Console.WriteLine("NOP encountered!");
                    cpu.NOP();
                    animationTimer.Stop();
                    fetchCounter = 0;
                    break;
                case opcodeLDAC:
                    Breakpoint(memoryCount);
                    // Perform actions for LDAC instruction
                    Console.WriteLine("LDAC encountered!");

                    if (ldacCounter < 3)
                    {
                        memoryLoc_txt.Text = m1.ToString();
                        Breakpoint(m1);
                        cpu.LDAC(instructadv1, ldacCounter);
                    }
                    else if (ldacCounter < 5)
                    {
                        memoryLoc_txt.Text = m2.ToString();
                        Breakpoint(m2);
                        cpu.LDAC(instructadv2, ldacCounter);
                    }
                    else
                    {
                        fetchCounter = 0;
                        ldacCounter = 0;
                        memoryCount += 3;
                        animationTimer.Stop();
                        break;
                    }
                    ldacCounter++;
                    break;
                case opcodeSTAC:
                    Breakpoint(memoryCount);
                    // Perform actions for STAC instruction
                    Console.WriteLine("STAC encountered!");
                    if (stacCounter == 0)
                    {
                        memoryLoc_txt.Text = m1.ToString();
                        Breakpoint(m1);
                        cpu.STAC(instructadv1, stacCounter);
                    }
                    else if (stacCounter < 4)
                    {
                        memoryLoc_txt.Text = m2.ToString();
                        Breakpoint(m2);
                        cpu.STAC(instructadv2, stacCounter);
                    }
                    else
                    {
                        memorycode[memoryCount] = cpu.STAC(instructadv2, stacCounter);
                        fetchCounter = 0;
                        stacCounter = 0;
                        memoryCount += 3;
                        animationTimer.Stop();
                        break;
                    }
                    stacCounter++;
                    break;
                case opcodeMVAC:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for MVAC instruction
                    Console.WriteLine("MVAC encountered!");
                    cpu.MVAC();
                    animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeMOVR:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for MOVR instruction
                    Console.WriteLine("MOVR encountered!");
                    cpu.MVAC();
                    animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeJUMP:
                    Breakpoint(memoryCount);
                    // Perform actions for JUMP instruction
                    Console.WriteLine("JUMP encountered!");
                    memoryLoc_txt.Text = memoryCount.ToString();
                    if (cpu.JUMP(instructadv1, memorycode) < 0)
                    {
                        Breakpoint(m1);
                        memoryLoc_txt.Text = m1.ToString();
                        memoryCount += 3;
                        Breakpoint(memoryCount);
                    }
                    else
                    {
                        Breakpoint(memoryCount);
                        memoryCount = cpu.JUMP(instructadv1, memorycode);
                    }
                    animationTimer.Stop();
                    fetchCounter = 0;
                    break;
                case opcodeJMPZ:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for JMPZ instruction
                    Console.WriteLine("JMPZ encountered!");
                    if (cpu.JMPZ(instructadv1, memorycode) < 0)
                    {
                        memoryCount += 3;
                    }
                    else
                    {
                        memoryCount = cpu.JMPZ(instructadv1, memorycode);
                    }
                    animationTimer.Stop();
                    fetchCounter = 0;
                    break;
                case opcodeJPNZ:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for JPNZ instruction
                    Console.WriteLine("JPNZ encountered!");
                    if (cpu.JPNZ(instructadv1, memorycode) < 0)
                    {
                        memoryLoc_txt.Text = m1.ToString();
                        memoryCount += 3;
                    }
                    else
                    {
                        memoryCount = cpu.JPNZ(instructadv1, memorycode);
                    }
                    animationTimer.Stop();
                    fetchCounter = 0;
                    break;
                case opcodeADD:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for ADD instruction
                    Console.WriteLine("ADD encountered!");
                    cpu.ADD();
                    animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeSUB:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for SUB instruction
                    Console.WriteLine("SUB encountered!");
                    cpu.SUB();
                    animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeINAC:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for INAC instruction
                    Console.WriteLine("INAC encountered!");
                    cpu.INAC();
                    animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeCLAC:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for CLAC instruction
                    Console.WriteLine("CLAC encountered!");
                    cpu.CLAC();
                    animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeAND:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for AND instruction
                    Console.WriteLine("AND encountered!");
                    cpu.AND();
                    animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeOR:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for OR instruction
                    Console.WriteLine("OR encountered!");
                    cpu.OR();
                    animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeXOR:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for XOR instruction
                    Console.WriteLine("XOR encountered!");
                    cpu.XOR();
                    animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeNOT:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for NOT instruction
                    Console.WriteLine("NOT encountered!");
                    cpu.NOT();
                    animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeEND:
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for END instruction
                    Console.WriteLine("END encountered!");
                    cpu.END();
                    animationTimer.Stop();
                    fullCycleTimer.Stop();
                    Console.WriteLine("It has finished");
                    break;
                default:
                    // Handle unknown instructions or implement additional instructions
                    Console.WriteLine("Instruction Does not Exist");
                    break;
            }
        }
        public void Breakpoint(int memcount)
        {
            foreach (int breaks in breakpoints)
            {
                if(memcount == breaks)
                {
                    cpu.Status_txt.Text = "Breaks";
                    animationTimer.Stop();
                    fullCycleTimer.Stop();
                }
            }
        }
        #endregion

        #region RSCPU Visualization Timers
        private void AnimationDone(object sender, EventArgs e)
        {
            ExecuteMicrocode();
        }

        private void FullCycle_Timer(object sender, EventArgs e)
        {
            ExecuteMicrocode();
        }
        #endregion

        private void btnFullCycle_Click(object sender, EventArgs e)
        {
            ResetRegisters();
            cpu.ResetRegisters();
            fetchCounter = 0;
            memoryCount = 0;
            memorycode = memory.GetInstructions();
            fullCycleTimer.Start();
            if (memoryCount == memorycode.Length)
            {
                fullCycleTimer.Stop();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ResetRegisters();
            cpu.ResetRegisters();
            fetchCounter = 0;
            memoryCount = 0;
            memorycode = memory.GetInstructions();
            ExecuteMicrocode();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            ExecuteMicrocode();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            cpu.Status_txt.Text = "Paused";
            animationTimer.Stop();
            fullCycleTimer.Stop();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            cpu.Status_txt.Text = "Running";
            animationTimer.Start();
            fullCycleTimer.Start();
        }
    }
}
