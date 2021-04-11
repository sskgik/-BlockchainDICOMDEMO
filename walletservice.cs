using System;
using System.Threading.Tasks;
using System.Net.Http;
using Miyabi;
using Miyabi.NFT.Client;
using Miyabi.NFT.Models;
using Miyabi.Entity.Client;
using Miyabi.Entity.Models;
using Miyabi.ClientSdk;
using Miyabi.Common.Models;
using Miyabi.Cryptography;
using System.Collections.Generic;
using System.Diagnostics;

namespace WalletService
{

    /// <summary>
    /// Wallt action class.
    /// </summary>
    public class WAction
    {
        private static string ApiUrl = "https://playground.blockchain.bitflyer.com/";
       
        /// <summary>
        /// show Asset of designated publickeyAddress
        /// </summary>
        /// <param name="publickey">開示するパブリックキー </param>
        /// <param name="tablename">情報を開示するテーブルネーム</param>
        /// <returns>result.Value</returns>
        public async Task<string> ShowNFTOwner(string tablename, string Querypublickey )
        {
            PublicKeyAddress Hospitalpublickey = null;
            var tokenid = "";
            var client = this.SetClient();
            var nftclient = new NFTClient(client);
            try
            {
                var value = PublicKey.Parse(Querypublickey);
                Hospitalpublickey = new PublicKeyAddress(value);
            }
            catch (Exception)
            {
                return null;
            }
            var result = await nftclient.GetNFTTableAsync(tablename);
            foreach (KeyValuePair<String, Address> Indexelement in result.Value)
            {
                if(Indexelement.Value == Hospitalpublickey)
                {
                     if(Indexelement.Key == "10000053")
                    {
                        tokenid = Indexelement.Key;
                    }   
                }
            }
            return tokenid;
        }

        /// <summary>
        /// Send Transaction to miyabi blockchain
        /// </summary>
        /// <param name="tx">トランザクション情報</param>
        /// <returns></returns>
        public async Task SendTransaction(Transaction tx)
         {
            var client = this.SetClient();
            var generalClient = new GeneralApi(client);

            try
            {
                var send = await generalClient.SendTransactionAsync(tx);
                var result_code = send.Value;

                if (result_code != TransactionResultCode.Success
                   && result_code != TransactionResultCode.Pending)
                {
                    // Console.WriteLine("取引が拒否されました!:\t{0}", result_code);
                }
            }
            catch (Exception)
            {
                // Console.Write("例外を検知しました！{e}");
                return;
            }
         }
        /// <summary>
        ///  Get Publickey from Keypair
        /// </summary>
        /// <returns></returns>
        public Address GetAddress(KeyPair formerkeypair)
        {
            return new PublicKeyAddress(formerkeypair);
        }

         /// <summary>
         /// client set method.
         /// </summary>
         /// <returns>client</returns>
        public Client SetClient()
        {
            Client client;
            var config = new SdkConfig(ApiUrl);
            client = new Client(config);
            return client;
        }
        /// <summary>
        /// トランザションの結果判定
        /// </summary>
        /// <param name="api"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<string> WaitTx(GeneralApi api, ByteString id)
        {
            while (true)
            {
                var result = await api.GetTransactionResultAsync(id);
                if (result.Value.ResultCode != TransactionResultCode.Pending)
                {
                    return result.Value.ResultCode.ToString();
                }
            }
        }
        /// <summary>
        ///  プライベートキー文字列のParse
        /// </summary>
        /// <param name="privateKey">プライベートキーの文字列</param>
        /// <returns></returns>
        public KeyPair GetKeyPair(string privateKey)
        {
            PrivateKey adminPrivateKey;
            try
            {
                 adminPrivateKey = PrivateKey.Parse(privateKey);
            }
            catch(Exception)
            {
                //失敗のHTTPリクエストを投げるようにする
                return null;
            }
            return new KeyPair(adminPrivateKey);
        }
    }
}