﻿/*
The MIT License (MIT)

Copyright (c) 2018 Giovanni Paolo Vigano'

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;
using TMPro;

/// <summary>
/// Examples for the M2MQTT library (https://github.com/eclipse/paho.mqtt.m2mqtt),
/// </summary>
namespace M2MqttUnity.Examples
{
    /// <summary>
    /// Script for testing M2MQTT with a Unity UI
    /// </summary>
    public class M2MqttUnityShellyPlug : M2MqttUnityClient
    {
        [Tooltip("Set this to true to perform a testing cycle automatically on startup")]
        public bool autoTest = false;
        [Header("User Interface")]
        public InputField consoleInputField;
        public Toggle encryptedToggle;
        public InputField addressInputField;
        public InputField portInputField;
        public Button connectButton;
        public Button disconnectButton;
        public Button testPublishButton;
        public Button clearButton;

        [SerializeField] private AudioClip sensorUpdateSound;
        [SerializeField] private AudioSource audioSource;

        public string sensorID1 = "a8-17-58-ff-fe-03-10-5b";
        public string sensorID2 = "a8-17-58-ff-fe-03-0d-4e";

        public CorrectPassword correctPassword;

        public TMP_Text co2Data1_text;
        public TMP_Text co2Data2_text;

        private List<string> eventMessages = new List<string>();
        private bool updateUI = false;

        public void TestPublish()
        {
            client.Publish("shellyplusplugs-fcb4670cdbf0/events/rpc", System.Text.Encoding.UTF8.GetBytes("Test message"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("Test message published");
            AddUiMessage("Test message published.");
        }

        public void SetBrokerAddress(string brokerAddress)
        {
            if (addressInputField && !updateUI)
            {
                this.brokerAddress = brokerAddress;
            }
        }

        public void SetBrokerPort(string brokerPort)
        {
            if (portInputField && !updateUI)
            {
                int.TryParse(brokerPort, out this.brokerPort);
            }
        }

        public void SetEncrypted(bool isEncrypted)
        {
            this.isEncrypted = isEncrypted;
        }


        public void SetUiMessage(string msg)
        {
            if (consoleInputField != null)
            {
                consoleInputField.text = msg;
                updateUI = true;
            }
        }

        public void AddUiMessage(string msg)
        {
            if (consoleInputField != null)
            {
                consoleInputField.text += msg + "\n";
                updateUI = true;
            }
        }

        protected override void OnConnecting()
        {
            base.OnConnecting();
            SetUiMessage("Connecting to broker on " + brokerAddress + ":" + brokerPort.ToString() + "...\n");
        }

        protected override void OnConnected()
        {
            base.OnConnected();
            SetUiMessage("Connected to broker on " + brokerAddress + "\n");

            if (autoTest)
            {
                TestPublish();
            }
        }

        protected override void SubscribeTopics()
        {
            client.Subscribe(new string[] { "shellyplusplugs-fcb4670cdbf0/events/rpc" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        protected override void UnsubscribeTopics()
        {
            client.Unsubscribe(new string[] { "shellyplusplugs-fcb4670cdbf0/events/rpc" });
        }

        protected override void OnConnectionFailed(string errorMessage)
        {
            AddUiMessage("CONNECTION FAILED! " + errorMessage);
        }

        protected override void OnDisconnected()
        {
            AddUiMessage("Disconnected.");
        }

        protected override void OnConnectionLost()
        {
            AddUiMessage("CONNECTION LOST!");
        }

        private void UpdateUI()
        {
            if (client == null)
            {
                if (connectButton != null)
                {
                    connectButton.interactable = true;
                    disconnectButton.interactable = false;
                    testPublishButton.interactable = false;
                }
            }
            else
            {
                if (testPublishButton != null)
                {
                    testPublishButton.interactable = client.IsConnected;
                }
                if (disconnectButton != null)
                {
                    disconnectButton.interactable = client.IsConnected;
                }
                if (connectButton != null)
                {
                    connectButton.interactable = !client.IsConnected;
                }
            }
            if (addressInputField != null && connectButton != null)
            {
                addressInputField.interactable = connectButton.interactable;
                addressInputField.text = brokerAddress;
            }
            if (portInputField != null && connectButton != null)
            {
                portInputField.interactable = connectButton.interactable;
                portInputField.text = brokerPort.ToString();
            }
            if (encryptedToggle != null && connectButton != null)
            {
                encryptedToggle.interactable = connectButton.interactable;
                encryptedToggle.isOn = isEncrypted;
            }
            if (clearButton != null && connectButton != null)
            {
                clearButton.interactable = connectButton.interactable;
            }
            updateUI = false;
        }

        protected override void Start()
        {
            SetUiMessage("Ready.");
            updateUI = true;
            base.Start();
        }

        protected override void DecodeMessage(string topic, byte[] message)
        {
            string msg = System.Text.Encoding.UTF8.GetString(message);
            Debug.Log(msg);

            /*if (msg.Contains(sensorID1)){
                //make sound
                audioSource.PlayOneShot(sensorUpdateSound);
                Debug.Log(msg);
                StoreMessage(msg);
                string[] splitted_data = msg.Split(" ");
                String co2Data = splitted_data[15];
                String co2DataFinal = co2Data.Substring(0, co2Data.Length -1);
                
                Debug.Log(co2DataFinal);
                co2Data2_text.SetText(co2DataFinal);
                //correctPassword.SetPassword1(co2DataFinal);
            }
            if (msg.Contains(sensorID2)){
                //make sound
                audioSource.PlayOneShot(sensorUpdateSound);
                //Debug.Log(msg);
                StoreMessage(msg);
                string[] splitted_data2 = msg.Split(" ");
                String co2Data2 = splitted_data2[15];
                String co2DataFinal2 = co2Data2.Substring(0, co2Data2.Length -1);
                
                Debug.Log(co2DataFinal2);
                co2Data1_text.SetText(co2DataFinal2);
                //correctPassword.SetPassword2(co2DataFinal2);
            }*/
            //else{
                //Debug.Log("joku muu sensori");
            //}
            //Debug.Log("Received: " + msg);
            //StoreMessage(msg);
            //if (topic == "cwc/elsys/parsed")
            /*{
                if (autoTest)
                {
                    autoTest = false;
                    Disconnect();
                }
            }*/
        }

        private void StoreMessage(string eventMsg)
        {
            eventMessages.Add(eventMsg);
        }

        private void ProcessMessage(string msg)
        {
            AddUiMessage("Received: " + msg);
        }

        protected override void Update()
        {
            base.Update(); // call ProcessMqttEvents()

            if (eventMessages.Count > 0)
            {
                foreach (string msg in eventMessages)
                {
                    ProcessMessage(msg);
                }
                eventMessages.Clear();
            }
            if (updateUI)
            {
                UpdateUI();
            }
        }

        private void OnDestroy()
        {
            Disconnect();
        }

        private void OnValidate()
        {
            if (autoTest)
            {
                autoConnect = true;
            }
        }
        public void PublishOn()
        {
            client.Publish("shellyplusplugs-fcb4670cdbf0/rpc", System.Text.Encoding.UTF8.GetBytes("{\"id\":0,\"src\":\"shellies/myplug-083af20071ad/rpc\",\"method\":\"Switch.Set\",\"params\":{\"id\":0,\"on\":true}}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("turn switch on message published");
            //AddUiMessage("Test message published.");
        }
        public void PublishOff()
        {
            client.Publish("shellyplusplugs-fcb4670cdbf0/rpc", System.Text.Encoding.UTF8.GetBytes("{\"id\":0,\"src\":\"shellies/myplug-083af20071ad/rpc\",\"method\":\"Switch.Set\",\"params\":{\"id\":0,\"on\":false}}"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("turn switch off published");
            //AddUiMessage("Test message published.");
        }


    }

    
}
