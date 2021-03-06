import React,{ useState,useEffect } from 'react';
import './App.css';
import axios from 'axios'

function App() {
  const [selectedFile, setSelectedFile] = useState();
  const [selectedFile2, setSelectedFile2] = useState();
  const [selectedFile3, setSelectedFile3] = useState();
  const [selectedFile4, setSelectedFile4] = useState();
  const [state, setstate] = useState(0);
  var publickkeylist = ['031708d6179fb30886c5bbe795dec6d98717c914393eb7556c3a5b816e663958b1','02ac6eb6615f8e1f0f02b09b562c82374bc4dd01baec33e491b87d3863ff16bf0e','02680681c9d83141817559a31cd4b85156d2669e4530d7def5e6d11fb5a350e123','0266752d0e7cccc0c539cef223e4361adbf724cdbbb625a5fcb1e69bb1c1e92e11']
  useEffect(() => {
    getimageelement(publickkeylist[0])
    getimageelement(publickkeylist[1])
    getimageelement(publickkeylist[2])
    getimageelement(publickkeylist[3])
  }, [state]);

  const getimageelement = (publickey) =>{
    var array = []
    var TokenURI = 'https://sskgik.github.io/NFTcard/'
    var requesturi = 'https://localhost:44308/api/DICOMNFT?publickey='+publickey;
    axios.get(requesturi)
    .then(function (result){
      const data = result.data
      const style = {
        backgroundImage: 'url(' + TokenURI +  data + ')',
        backgroundPositionX: 'center',
        backgroundRepeat: 'no-repeat',
        backgroundSize: '100% 100%',
      }
       var elem = <div className='DicomImage' style={style}></div>
        switch (publickey) {
          case publickkeylist[0]:
            setSelectedFile(elem)
            break;
          case publickkeylist[1]:
            setSelectedFile2(elem)
            break;
          case publickkeylist[2]:
            setSelectedFile3(elem)
            break;
          case publickkeylist[3]:
            setSelectedFile4(elem)
            break;
        }
       
      }).catch(function (error){
        console.log(error)
      })     
  }

  var hospitalApubkey =  publickkeylist[0]
  var hospitalBpubkey =  publickkeylist[1]
  var hospitalCpubkey =  publickkeylist[2]
  var hospitalDpubkey =  publickkeylist[3]
  return (
    <div className='Mainpage'>
      <div className="Hospital A" onClick={()=>setstate(state+1)}>
        <p>A??????</p>
        {selectedFile}
        {/*<div className='DicomImage'></div>*/}
        <input className='PublickeyArea'  value={hospitalApubkey.slice(0,15)+'...'+hospitalApubkey.slice(-15)}  readOnly  />
      </div>
      <div className="Hospital B">
        <p>B??????</p>
        {selectedFile2}
        <input className='PublickeyArea'  value={hospitalBpubkey.slice(0,15)+'...'+hospitalBpubkey.slice(-15)} readOnly />
      </div>
      <div className="Hospital C">
        <p>C??????</p>
        {selectedFile3}
        <input className='PublickeyArea'  value={hospitalCpubkey.slice(0,15)+'...'+hospitalCpubkey.slice(-15)} readOnly />
      </div>
      <div className="Hospital D">
        <p>D??????</p>
        {selectedFile4}
        <input className='PublickeyArea'  value={hospitalDpubkey.slice(0,15)+'...'+hospitalDpubkey.slice(-15)} readOnly />
      </div>
      <div   className='InputtosendNFT  Inputformheaderpos'>
      <div  className='Inputformheader'>
        ???????????????????????????????????????
      </div>
      <div  className='InputArea'>
        <div   className='TosendchoiseArea'>
          <p>????????????????????????????????????</p>
          <select  className='SelectArea'>
            <option value="">??????????????????</option>
            <option value="031708d6179fb30886c5bbe795dec6d98717c914393eb7556c3a5b816e663958b1">A??????</option>
            <option value ="02ac6eb6615f8e1f0f02b09b562c82374bc4dd01baec33e491b87d3863ff16bf0e">B??????</option>
            <option value="02680681c9d83141817559a31cd4b85156d2669e4530d7def5e6d11fb5a350e123">C??????</option>
            <option value="0266752d0e7cccc0c539cef223e4361adbf724cdbbb625a5fcb1e69bb1c1e92e11">D??????</option>
          </select>
          <p>????????????????????????????????????</p>
          <select  className='SelectArea'>
            <option value="">??????????????????</option>
            <option value="031708d6179fb30886c5bbe795dec6d98717c914393eb7556c3a5b816e663958b1">A??????</option>
            <option value ="02ac6eb6615f8e1f0f02b09b562c82374bc4dd01baec33e491b87d3863ff16bf0e">B??????</option>
            <option value="02680681c9d83141817559a31cd4b85156d2669e4530d7def5e6d11fb5a350e123">C??????</option>
            <option value="0266752d0e7cccc0c539cef223e4361adbf724cdbbb625a5fcb1e69bb1c1e92e11">D??????</option>
          </select>
        </div>
      </div>
      <div  className='ConfirmbuttonArea'>
          <button  className='Confirmbutton'>??????</button>
        </div>
      </div>
    </div>
  );
}

export default App;
