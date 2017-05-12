
// Copyright 2017-+infinity Stefan Steiger
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


// Substitute for System.Timers.Timer 
// Partially implements old Timer class using System.Threading.Timer.
// https://github.com/Microsoft/referencesource/blob/master/System/services/timers/system/timers/Timer.cs

#define DOTNETCORE_LEGACY_COMPATIBILITY
#if DOTNETCORE_LEGACY_COMPATIBILITY 


namespace System.Timers
{


    // Summary:
    //     Stellt Daten für das System.Timers.Timer.Elapsed-Ereignis bereit.
    public class ElapsedEventArgs : System.EventArgs
    {

        protected System.DateTime m_signalTime;

        public ElapsedEventArgs()
        {
            this.m_signalTime = System.DateTime.Now;
        }


        // Zusammenfassung:
        //     Ruft die Zeit ab, zu der das System.Timers.Timer.Elapsed-Ereignis ausgelöst
        //     wurde.
        //
        // Rückgabewerte:
        //     Die Zeit, zu der das System.Timers.Timer.Elapsed-Ereignis ausgelöst wurde.
        public System.DateTime SignalTime { get { return this.m_signalTime; } }

    }

    public delegate void ElapsedEventHandler(object sender, ElapsedEventArgs e);


    // Namespace: LumiSoft.Net.TimerEx : System.Timers.Timer
    public class Timer : IDisposable //, System.ComponentModel.ISupportInitialize
    {
        protected System.Threading.Timer m_TaskTimer;


        public Timer() : this(0, true)
        { }


        public Timer(double interval) : this(interval, true)
        { }


        public Timer(double interval, bool autoReset)
        {
            this.Interval = interval;
            this.AutoReset = autoReset;
        }


        protected void internal_elapsed(object sender)
        {
            if (!this.AutoReset)
                this.Stop();

            ElapsedEventArgs eeargs = new ElapsedEventArgs();
            this.Elapsed(sender, eeargs);
        }


        public event ElapsedEventHandler Elapsed;



        // Zusammenfassung:
        //     Ruft einen Wert ab, der angibt, ob der System.Timers.Timer das System.Timers.Timer.Elapsed-Ereignis
        //     nach jedem oder nur nach dem ersten Ablaufen des Intervalls auslöst, oder
        //     legt diesen fest.
        //
        // Rückgabewerte:
        //     true, wenn System.Timers.Timer das System.Timers.Timer.Elapsed-Ereignis immer
        //     auslösen soll, wenn das Intervall abläuft, false, wenn das System.Timers.Timer.Elapsed-Ereignis
        //     nur einmal nach dem ersten Ablaufen des Intervalls ausgelöst werden soll.
        //     Die Standardeinstellung ist true.
        public bool AutoReset { get; set; }


        public bool m_Enabled;

        //
        // Zusammenfassung:
        //     Ruft einen Wert ab, der angibt, ob System.Timers.Timer das System.Timers.Timer.Elapsed-Ereignis
        //     auslösen soll, oder legt diesen fest.
        //
        // Rückgabewerte:
        //     true, wenn System.Timers.Timer das System.Timers.Timer.Elapsed-Ereignis auslösen
        //     soll, andernfalls false. Die Standardeinstellung ist false.
        //
        // Ausnahmen:
        //   System.ObjectDisposedException:
        //     Diese Eigenschaft kann nicht festgelegt werden, da der Zeitgeber freigegeben
        //     wurde.
        //
        //   System.ArgumentException:
        //     Die System.Timers.Timer.Interval-Eigenschaft wurde auf einen größeren Wert
        //     als System.Int32.MaxValue festgelegt, bevor der Timer aktiviert wurde.
        public bool Enabled
        {
            get
            {
                return this.m_Enabled;
            }

            set
            {
                if (value == m_Enabled)
                    return;


                if (this.m_Enabled) // value = false
                    this.Stop();
                else // value = true
                    this.Start();

                this.m_Enabled = value;
            }
        }

        protected double m_interval;

        //
        // Zusammenfassung:
        //     Ruft das Intervall ab, in dem das System.Timers.Timer.Elapsed-Ereignis ausgelöst
        //     wird, oder legt dieses fest.
        //
        // Rückgabewerte:
        //     Die Zeit zwischen System.Timers.Timer.Elapsed-Ereignissen in Millisekunden.
        //     Der Wert muss größer als 0 (null) und kleiner als oder gleich System.Int32.MaxValue
        //     sein. Der Standardwert ist 100 Millisekunden.
        //
        // Ausnahmen:
        //   System.ArgumentException:
        //     Das Intervall ist kleiner oder gleich 0 (null). -oder- Das Intervall ist
        //     größer als System.Int32.MaxValue, und der Zeitgeber ist gegenwärtig aktiviert.
        //     (Wenn der Zeitgeber nicht gerade aktiviert ist, wird keine Ausnahme ausgelöst,
        //     bis er aktiviert wird.)
        public double Interval
        {
            get
            {
                return this.m_interval;
            }
            set
            {
                this.m_interval = value;

                if (this.m_TaskTimer == null)
                    return;

                int mils = (int)this.Interval;
                System.TimeSpan ts = new System.TimeSpan(0, 0, 0, 0, mils);
                this.m_TaskTimer.Change(new System.TimeSpan(0), ts);
            }
        }




        // int mils = (int)this.Interval;
        // System.TimeSpan ts = new System.TimeSpan(0, 0, 0, 0, mils);

        //
        // Zusammenfassung:
        //     Ruft die Site ab, die die System.Timers.Timer-Klasse im Entwurfsmodus an
        //     ihren Container bindet, oder legt diese fest.
        //
        // Rückgabewerte:
        //     Eine System.ComponentModel.ISite-Schnittstelle, die die Site darstellt, die
        //     das System.Timers.Timer-Objekt an ihren Container bindet.
        // public System.ComponentModel.ISite Site { get; set; }

        //
        // Zusammenfassung:
        //     Ruft das Objekt ab, das zum Marshallen von Ereignishandleraufrufen verwendet
        //     wird, die nach Ablauf eines Intervalls ausgegeben werden, oder legt dieses
        //     fest.
        //
        // Rückgabewerte:
        //     Die System.ComponentModel.ISynchronizeInvoke-Schnittstelle, die das Objekt
        //     zum Marshallen von Ereignishandleraufrufen darstellt, die nach Ablauf eines
        //     Intervalls ausgegeben werden. Der Standardwert ist null.
        // public System.ComponentModel.ISynchronizeInvoke SynchronizingObject { get; set; }






        //
        // Zusammenfassung:
        //     Beginnt mit dem Auslösen des System.Timers.Timer.Elapsed-Ereignisses durch
        //     Festlegen von System.Timers.Timer.Enabled auf true.
        //
        // Ausnahmen:
        //   System.ArgumentOutOfRangeException:
        //     Der System.Timers.Timer wird mit einem Intervall größer oder gleich System.Int32.MaxValue
        //     + 1 erstellt oder auf ein Intervall kleiner als null festgelegt.
        public void Start()
        {
            int mils = (int)this.Interval;
            System.TimeSpan ts = new System.TimeSpan(0, 0, 0, 0, mils);

            if (this.m_TaskTimer == null)
            {
                this.m_TaskTimer = new System.Threading.Timer(
                    new System.Threading.TimerCallback(this.internal_elapsed)
                    , null, ts, ts
                );
            }
            else
                this.m_TaskTimer.Change(ts, ts);
        }


        //
        // Zusammenfassung:
        //     Unterbricht das Auslösen des System.Timers.Timer.Elapsed-Ereignisses durch
        //     Festlegen von System.Timers.Timer.Enabled auf false.
        public void Stop()
        {
            if (this.m_TaskTimer == null)
                return;

            this.m_TaskTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        }


        public void Dispose()
        {
            this.Dispose(true);
        }


        void IDisposable.Dispose()
        {
            this.Dispose(true);
        }


        //
        // Zusammenfassung:
        //     Gibt alle von der aktuellen System.Timers.Timer-Klasse verwendeten Ressourcen
        //     frei.
        //
        // Parameter:
        //   disposing:
        //     true, um sowohl verwaltete als auch nicht verwaltete Ressourcen freizugeben,
        //     false, um ausschließlich nicht verwaltete Ressourcen freizugeben.
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Stop();
                if (this.m_TaskTimer != null)
                    this.m_TaskTimer.Dispose();

                this.m_TaskTimer = null;
                this.Elapsed = null;
            }
        }

        //
        // Zusammenfassung:
        //     Gibt die von System.Timers.Timer verwendeten Ressourcen frei.
        public void Close()
        {
            this.Dispose(true);
        }


        //// Zusammenfassung:
        ////     Beginnt die Laufzeitinitialisierung eines System.Timers.Timer, der in einem
        ////     Formular oder von einer anderen Komponente verwendet wird.
        //void ComponentModel.ISupportInitialize.BeginInit()
        //{
        //    throw new System.NotImplementedException("BeginInit");
        //}


        ////
        //// Zusammenfassung:
        ////     Beendet die Laufzeitinitialisierung eines System.Timers.Timer, der in einem
        ////     Formular oder von einer anderen Komponente verwendet wird.
        //void ComponentModel.ISupportInitialize.EndInit()
        //{
        //    throw new System.NotImplementedException("EndInit");
        //}


    } // End Class MyTimer 


} // End Namespace System.Timers 


#endif
