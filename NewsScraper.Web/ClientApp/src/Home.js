
import React, {useState, useEffect} from "react";
import axios from "axios";



const Home=()=>{


    const [newsPosts, setNewsPosts] = useState([])

  

     const getNewsPosts= async()=>{
          
            const {data} = await axios.get('/api/news/scrapetls');
            setNewsPosts(data)
        }


    useEffect(() => {
        getNewsPosts();
      }, []);


return (
    <div className="container mt-5">

        <h5>The Lakewood Scoop Headlines!!!</h5>
        <div className="row mt-3">
            <table className=" table table-striped table-hover table- bordered">
                <thead>
                    <tr>
                        <th> Title:</th>
                        <th>Picture:</th>
                        <th>Textblurb:</th>
                        <th>Comments/Submit Comment</th>
                    </tr>
                </thead>
                <tbody>
                    {newsPosts.map((post, id)=>{
                        return <tr key={id}>
                           <td>
                               <a href={post.link} target='_blank'>{post.title}</a>
                           </td>
                            <td> <img height={100} width={100} src={post.imageUrl}/></td> 
                           <td>{post.textBlurb}</td>
                        
                           <td>
                               <a href={post.submitComment} target='_blank'>{post.commentsAmount}</a>
                           </td>
                        </tr>
                        
                        
                    })}
                </tbody>
            </table>
        </div>
    </div>
)

}


export default Home;