'use server';

import {Question} from "@/lib/types";
import {fetchClient} from "@/lib/fetchClient";

export async function getQuestions(tag?: string) {
    let url = '/questions';
    if(tag) url += '?tag=' + tag;
    
    return fetchClient<Question[]>(url, 'GET');
    
    // const response = await fetch(url);
    //
    // if(!response.ok) throw new Error('Failed to get questions');
    //
    // return response.json();
}

export async function getQuestionById(id: string) {
    const url = `/questions/${id}`;

    return fetchClient<Question>(url, 'GET');
}


export async function searchQuestios(query: string) {
    return fetchClient<Question[]>(`/search?query=${query}`, 'GET');
}