using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RtMidi.Core.Devices;
using RtMidi.Core;
using RtMidi.Core.Messages;
using RtMidi.Core.Enums;
using System.Threading;

namespace ScoreReader.Core
{
    public class PedalManager : IDisposable
    {
        private IMidiInputDevice _inputDevice;
        private IMidiOutputDevice _outputDevice;
        private DateTime _pushStart = DateTime.MaxValue;

        public event EventHandler<SoftPedalPushEventArgs> SoftPedal_Push;

        public void Init()
        {
            var slIn = MidiDeviceManager.Default.InputDevices.SingleOrDefault(i => i.Name == "SL GRAND ");
            var slOut = MidiDeviceManager.Default.OutputDevices.SingleOrDefault(i => i.Name == "kipy_loopback1 ");
            if (slIn != null)
            {
                _inputDevice = slIn.CreateDevice();
                _inputDevice.ControlChange += InputDevice_ControlChange;
                _inputDevice.NoteOn += InputDevice_NoteOn;
                _inputDevice.NoteOff += _inputDevice_NoteOff;
                _inputDevice.Nrpn += _inputDevice_Nrpn;
                _inputDevice.ChannelPressure += _inputDevice_ChannelPressure;
                _inputDevice.PitchBend += _inputDevice_PitchBend;
                _inputDevice.PolyphonicKeyPressure += _inputDevice_PolyphonicKeyPressure;
                _inputDevice.ProgramChange += _inputDevice_ProgramChange;
                _inputDevice.Open();

                _outputDevice = slOut.CreateDevice();
                _outputDevice.Open();
            }
        }

        public void Dispose()
        {
            _inputDevice.ControlChange -= InputDevice_ControlChange;
            _inputDevice.NoteOn -= InputDevice_NoteOn;
            _inputDevice.NoteOff -= _inputDevice_NoteOff;
            _inputDevice.Nrpn -= _inputDevice_Nrpn;
            _inputDevice.ChannelPressure -= _inputDevice_ChannelPressure;
            _inputDevice.PitchBend -= _inputDevice_PitchBend;
            _inputDevice.PolyphonicKeyPressure -= _inputDevice_PolyphonicKeyPressure;
            _inputDevice.ProgramChange -= _inputDevice_ProgramChange;
            _inputDevice.Dispose();

            _outputDevice.Dispose();
        }

        private void _inputDevice_ProgramChange(IMidiInputDevice sender, in ProgramChangeMessage msg)
        {
            _outputDevice.Send(msg);
        }

        private void _inputDevice_PolyphonicKeyPressure(IMidiInputDevice sender, in PolyphonicKeyPressureMessage msg)
        {
            _outputDevice.Send(msg);
        }

        private void _inputDevice_PitchBend(IMidiInputDevice sender, in PitchBendMessage msg)
        {
            _outputDevice.Send(msg);
        }

        private void _inputDevice_ChannelPressure(IMidiInputDevice sender, in ChannelPressureMessage msg)
        {
            _outputDevice.Send(msg);
        }

        private void _inputDevice_Nrpn(IMidiInputDevice sender, in NrpnMessage msg)
        {
            _outputDevice.Send(msg);
        }

        private void _inputDevice_NoteOff(IMidiInputDevice sender, in NoteOffMessage msg)
        {
            _outputDevice.Send(msg);
        }

        private void InputDevice_NoteOn(IMidiInputDevice sender, in NoteOnMessage msg)
        {
            _outputDevice.Send(msg);
        }

        private bool _pedalState = false;
        private void InputDevice_ControlChange(IMidiInputDevice sender, in ControlChangeMessage msg)
        {
            _outputDevice.Send(msg);

            if (msg.ControlFunction == ControlFunction.SoftPedalOnOff && msg.Channel == Channel.Channel1)
            {
                if (msg.Value == 127 && !_pedalState)
                    SetPedalState(true);

                if (msg.Value == 0 && _pedalState)
                    SetPedalState(false);
            }
        }

        private void SetPedalState(bool pushed)
        {
            _pedalState = pushed;

            if(_pedalState)
                _pushStart = DateTime.UtcNow;
            else
            {
                if((DateTime.UtcNow - _pushStart).TotalSeconds < 0.3)
                    SoftPedal_Push?.Invoke(this, new SoftPedalPushEventArgs(PushType.Short));
                else
                    SoftPedal_Push?.Invoke(this, new SoftPedalPushEventArgs(PushType.Long));
            }

            
        }
    }

    public enum PushType
    {
        Short,
        Long
    }

    public class SoftPedalPushEventArgs : EventArgs
    {
        public PushType Type { get; private set; }

        public SoftPedalPushEventArgs(PushType type)
            : base()
        {
            Type = type;
        }
    }
}
